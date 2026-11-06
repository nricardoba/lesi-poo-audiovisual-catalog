# Cliffhanger

### Audiovisual Catalog Management

Cliffhanger is a C# / .NET 10 console application for managing a catalog of movies and film professionals ("stars"). Developed for the **Object-Oriented Programming (Programação Orientada a Objetos)** course, it combines an interactive terminal interface, layered validation, a generic repository, and local file persistence.

**Final grade: 18/20.**

## Features

- **Movie management:** Add, view, edit, and remove movies with a title, release year, duration, and MPA age rating (`G`, `PG`, `PG13`, or `R`).
- **Star management:** Add, view, edit, and remove stars with a name, birth date, and job role (`Unemployed`, `Director`, `Writer`, or `Actor`).
- **Record lookup:** Retrieve, edit, or remove records by their unique ID (`Guid`) or repository index.
- **Listing and sorting:** Display each repository and sort its records by name.
- **Validation:** Check input integrity in the domain layer and business rules in the service layer.
- **Local persistence:** Save and load repositories as GZip-compressed JSON stored in `.bin` files.

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) — the SDK is required to build and run the source code.
- An interactive terminal. An IDE is optional; the repository includes Visual Studio Code configuration.

Check that the SDK is available:

```sh
dotnet --version
```

### Build and run

Run the following commands from the repository root (the directory containing `Cliffhanger.sln`):

```sh
dotnet restore Cliffhanger.sln
dotnet build Cliffhanger.sln --no-restore
```

Create the data directory before saving for the first time. In a POSIX shell (macOS/Linux):

```sh
mkdir -p src/Bin
```

On Windows, create the `src/Bin` folder using your shell or file manager.

Start the application:

```sh
dotnet run --project src/Presentation/Presentation.csproj --no-build
```

> Run from the repository root so that the relative data paths resolve consistently. The application does not create the data directory automatically.

## Usage

1. At startup, choose **Load data from binary file** to restore saved records, or **Start with a fresh database** to begin with empty repositories.
2. Open the **Star Repository** or **Movie Repository** from the main menu.
3. Use the repository menu to list, look up, add, remove, edit, or sort records.
4. Return to the main menu and select **Save data on binary file** to persist both repositories.
5. Select **0** to go back from a repository menu or quit from the main menu.

> **Saving is manual.** Quitting does not save changes. Starting fresh leaves existing files untouched until you save; saving then overwrites them with the current repositories.

## Data Storage

Records are held in memory during a session. The save option writes two separate files:

| Repository | Default file        |
| ---------- | ------------------- |
| Stars      | `src/Bin/Star.bin`  |
| Movies     | `src/Bin/Movie.bin` |

Despite the `.bin` extension, these files contain **JSON compressed with GZip**, not a relational database or plain-text JSON. No database server is required.

Paths are defined in [`src/BusinessObjects/Config.cs`](src/BusinessObjects/Config.cs) and are relative to the process's current working directory. The `src/Bin/` directory is ignored by Git, so saved catalog data is not version-controlled.

## Architecture

The solution is organized into five projects with separate responsibilities:

| Project             | Responsibility                                                                                           |
| ------------------- | -------------------------------------------------------------------------------------------------------- |
| **Presentation**    | Application entry point, console menus, input/output, and operation dispatch.                            |
| **BusinessLogic**   | Movie and star services, business-rule validation, and repository access through `GlobalRepoControl<T>`. |
| **BusinessObjects** | Domain models, the shared `Identifier` base class, enums, configuration, and integrity validation.       |
| **Data**            | In-memory repositories, ID handling, and file persistence through `GlobalRepo<T>`.                       |
| **Exceptions**      | Custom repository exceptions.                                                                            |

The code demonstrates inheritance, generics, comparison, and cloning. `Movie` and `Star` share the `Identifier` base class; the generic repository reuses storage operations across both types. The business-logic layer returns cloned records when retrieving data for the presentation layer.

### Project structure

```text
Cliffhanger.sln
src/
├── BusinessObjects/    # Domain models, enums, configuration, and integrity checks
├── BusinessLogic/      # Services, business rules, and repository control
├── Data/               # Generic repository, ID handling, and persistence
├── Exceptions/         # Custom repository exceptions
├── Presentation/       # Console application and menus
└── Bin/                # Local data files (create before saving; ignored by Git)
```

## Academic Context

Developed for the **Object-Oriented Programming** course, with a final grade of **18 out of 20**.
