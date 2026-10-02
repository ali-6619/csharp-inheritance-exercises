# C# Inheritance Exercises

Four independent OOP exercises covering class hierarchies, constructors,
`base(...)` calls, and polymorphism.

## Exercise 1 — Vehicle Hierarchy

```
Vehicle
  |-- Car
  |-- Bus
  `-- Motorcycle
```

| Class        | Members                    | Notes                          |
|--------------|----------------------------|--------------------------------|
| `Vehicle`    | `Brand`, `Year`, `Start()` | base class                     |
| `Car`        | `NumberOfDoors`            | calls `: base(brand, year)`    |
| `Bus`        | `Capacity`                 | calls `: base(brand, year)`    |
| `Motorcycle` | `HasSidecar`               | calls `: base(brand, year)`    |

`Start()` is declared once in `Vehicle` and never overridden, so all three
derived objects inherit and share it. The demo proves this both by direct
calls and through a `Vehicle[]` reference.

## Exercise 2 — University Members

```
Person
  |-- Student
  `-- Employee
        `-- Teacher
```

| Class      | Members                              | Notes                        |
|------------|--------------------------------------|------------------------------|
| `Person`   | `Name`, `Email`, `DisplayBasicInfo()`| `virtual` method             |
| `Student`  | `StudentId`, `GPA`                   | `override` + `base()` call   |
| `Employee` | `EmployeeId`, `Salary`               | `override` + `base()` call   |
| `Teacher`  | `CourseName`, `Teach()`              | inherits from `Employee`     |

The console output prints the **constructor execution order**, which for
`Teacher` is: `Person` -> `Employee` -> `Teacher`, because each constructor
delegates upward with `base(...)`.

`teacher is Employee` is `True` (it inherits from it), while
`student is Employee` is `False` (it does not).

## Key rules demonstrated

- `base(...)` must be the **first statement** in a constructor, otherwise
  CS1737 / CS0108-type errors occur.
- An overridden method can call `base.Method()` to reuse the parent version
  and append its own output.
- A `virtual` method is resolved at **runtime**, so calling through a
  `Person[]` still runs `Student`/`Teacher` versions.

## Run

```powershell
dotnet run --project .\Exercise1_VehicleHierarchy\Exercise1_VehicleHierarchy.csproj
dotnet run --project .\Exercise2_UniversityMembers\Exercise2_UniversityMembers.csproj
```

Or open `HierarchyExercises.slnx` in Visual Studio / Rider / VS Code.
