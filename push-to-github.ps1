#Requires -Version 5.1
<#
    push-to-github.ps1
    -------------------
    Authenticates the GitHub CLI, then creates a PRIVATE repository and pushes
    this folder to it.

    Run it in PowerShell:

        .\push-to-github.ps1

    It is interactive on purpose: `gh auth login` needs you to approve a
    one-time code in your browser, and that code expires within minutes -- so
    it must be one uninterrupted interaction.

    Implementation note: every check on a native command runs inside a helper
    with $ErrorActionPreference forced to 'Continue' and both streams captured.
    With the default 'Stop', gh writing to stderr (which it does on every
    failed auth check) raises a terminating error and kills the script before
    it ever reaches the login step.
#>

$repoName = 'csharp-inheritance-exercises'

Set-Location -Path $PSScriptRoot

# --- helpers ----------------------------------------------------------------
# Run a native command, capture stdout+stderr, never throw.
function Invoke-Native {
    param([string]$FilePath, [string[]]$Arguments = @())
    $prev = $ErrorActionPreference
    $ErrorActionPreference = 'Continue'
    try {
        $out = & $FilePath @Arguments 2>&1
        $code = $LASTEXITCODE
    }
    finally {
        $ErrorActionPreference = $prev
    }
    [pscustomobject]@{
        ExitCode = $code
        Output   = ($out | ForEach-Object { [string]$_ }) -join "`n"
    }
}

function Fail {
    param([string]$Message)
    Write-Host ''
    Write-Host "FAILED: $Message" -ForegroundColor Red
    exit 1
}

# --- locate the tools -------------------------------------------------------
$ghCmd = Get-Command gh -ErrorAction SilentlyContinue
$gh = if ($ghCmd) { $ghCmd.Source } else { 'C:\Program Files\GitHub CLI\gh.exe' }
if (-not (Test-Path $gh)) { Fail "GitHub CLI not found. Install it with: winget install GitHub.cli" }

$gitCmd = Get-Command git -ErrorAction SilentlyContinue
$git = if ($gitCmd) { $gitCmd.Source } else { 'C:\Program Files\Git\cmd\git.exe' }
if (-not (Test-Path $git)) { Fail "Git not found. Install it with: winget install Git.Git" }

Write-Host "gh  -> $gh"   -ForegroundColor DarkGray
Write-Host "git -> $git"  -ForegroundColor DarkGray
Write-Host "repo -> $repoName (private)" -ForegroundColor DarkGray
Write-Host ''

# --- 1. authenticate --------------------------------------------------------
$auth = Invoke-Native $gh @('auth', 'status')

if ($auth.ExitCode -ne 0) {
    Write-Host 'Not logged in yet -- starting device login.' -ForegroundColor Yellow
    Write-Host 'A one-time code appears below. Open it at:' -ForegroundColor Yellow
    Write-Host '    https://github.com/login/device' -ForegroundColor White
    Write-Host 'then press Authorize. Finish within a few minutes.' -ForegroundColor Yellow
    Write-Host ''

    # not captured: the user must see the live code and the browser must open
    & $gh auth login --hostname github.com --git-protocol https --web
    if ($LASTEXITCODE -ne 0) { Fail 'Login was cancelled or failed.' }

    $auth = Invoke-Native $gh @('auth', 'status')
    if ($auth.ExitCode -ne 0) { Fail 'Still not logged in after the login step.' }
}

Invoke-Native $gh @('auth', 'setup-git') | Out-Null

$loginRes  = Invoke-Native $gh @('api', 'user', '--jq', '.login')
$idRes     = Invoke-Native $gh @('api', 'user', '--jq', '.id')
if ($loginRes.ExitCode -ne 0 -or -not $loginRes.Output.Trim()) { Fail "Could not read the GitHub login: $($loginRes.Output)" }

$login  = $loginRes.Output.Trim()
$userId = $idRes.Output.Trim()
Write-Host "Logged in as: $login" -ForegroundColor Green

# --- 2. git identity (noreply form keeps the address private) ---------------
$noReply = "$userId+$login@users.noreply.github.com"
Invoke-Native $git @('config', 'user.name',  $login)          | Out-Null
Invoke-Native $git @('config', 'user.email', $noReply)         | Out-Null
Write-Host "git identity: $login <$noReply>" -ForegroundColor DarkGray

# --- 3. commit --------------------------------------------------------------
if (-not (Test-Path '.git')) { Invoke-Native $git @('init', '-b', 'main') | Out-Null }
Invoke-Native $git @('add', '-A') | Out-Null

$diff = Invoke-Native $git @('diff', '--cached', '--quiet')
if ($diff.ExitCode -ne 0) {
    $commit = Invoke-Native $git @('commit', '-q', '-m',
        'Add C# inheritance exercises: vehicle hierarchy and university members')
    if ($commit.ExitCode -ne 0) { Fail "Commit failed: $($commit.Output)" }
    Write-Host 'Committed.' -ForegroundColor Green
}
else {
    Write-Host 'Nothing staged to commit.' -ForegroundColor DarkGray
}

# --- 4. create the PRIVATE repo and push -----------------------------------
$remote = "https://github.com/$login/$repoName.git"

$exists = Invoke-Native $gh @('repo', 'view', "$login/$repoName")
if ($exists.ExitCode -eq 0) {
    Write-Host "Repository $login/$repoName already exists -- pushing to it." -ForegroundColor Yellow
    $remotes = (Invoke-Native $git @('remote')).Output
    if ($remotes -match '(?m)^origin\s') { Invoke-Native $git @('remote', 'set-url', 'origin', $remote) | Out-Null }
    else                                  { Invoke-Native $git @('remote', 'add', 'origin', $remote)          | Out-Null }
    $push = Invoke-Native $git @('push', '-u', 'origin', 'main')
    if ($push.ExitCode -ne 0) { Fail "Push failed: $($push.Output)" }
}
else {
    Write-Host "Creating PRIVATE repository $login/$repoName ..." -ForegroundColor Cyan
    $create = Invoke-Native $gh @('repo', 'create', $repoName, '--private', '--source=.', '--remote=origin', '--push')
    if ($create.ExitCode -ne 0) { Fail "Could not create the repository: $($create.Output)" }
}

Write-Host ''
Write-Host 'Done.  https://github.com/' + $login + '/' + $repoName -ForegroundColor Green