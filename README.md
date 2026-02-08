# POO Project - Cliffhanger: Audiovisual Catalog Management

## Description

This project, developed for the Object-Oriented Programming (Programação Orientada a Objetos) course, is a C# .NET console application for managing a movie and star database. It allows creating, editing, removing, searching, and listing movies and stars, with data validation, binary file persistence, and an interactive terminal interface.

## Features

- **Movie Management:** Creation, editing, removal, search, and listing of movies (with year, duration, and MPA age rating).
- **Star Management:** Creation, editing, removal, search, and listing of stars (with birth date and job role such as Director, Writer, or Actor).
- **Data Validation:** Input integrity and business rule validation at both the object and service layers.
- **Persistence:** Reading and writing repository data to compressed binary files (JSON + GZip).
- **Generic Repository:** A single generic data layer that handles storage for both Movies and Stars.
- **Layered Architecture:** Separation into Business Objects, Business Logic, Data, Exceptions, and Presentation layers.
- **Terminal Interface:** Interactive console menus for all operations.

## Architecture

- **N-Tier Architecture:** The project follows an N-tier layered structure, with clearly separated layers for Presentation, Business Logic, Business Objects, Data Access, and Exceptions, ensuring a clean separation of concerns.
- **SOLID Principles:** The codebase adheres to the SOLID principles of object-oriented design, promoting single responsibility across classes, open/closed extensibility through inheritance and generics, and dependency inversion between layers.

## Project Structure

```
Cliffhanger.sln
src/
  BusinessObjects/    # Domain models (Movie, Star, Identifier), enums, config, and validators
  BusinessLogic/      # Service classes and business rule validation
  Data/               # Generic repository (binary file I/O)
  Exceptions/         # Custom exception classes
  Presentation/       # Console UI, menus, and user interaction
```

## Technologies

- **Language:** C# (.NET 10.0)
- **IDE:** Visual Studio Code
