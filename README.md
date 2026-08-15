# To-Do List Manager

A basic to-do list manager by Logan Young, built in C# with .NET 7. This is a showcase/learning project, not a production application, so keep expectations at "demo" level rather than "polished product."

The repo contains two separate apps that share the same idea (tasks, categories, and simple to-do items) but are built with different interfaces:

- **CLI app** (`ToDoAppCLI`): a console app at the root of the repo. Minimal and quick to run anywhere.
- **GUI app** (`GUI/`): a WPF desktop app with a richer feature set. Windows only.

## Features

### CLI (`ToDoAppCLI`)

A menu driven console app. Users can:

- Add a task with a description and category
- Remove a task by number
- List all tasks
- Add a new category

It is intentionally simple, with no due dates, priorities, or saving.

### GUI (`GUI/`)

A WPF app with a more complete feature set. Users can:

- Add a **To-Do Item**, which includes a title, ID, description, labels, due date, priority, and category
- Add a **Task Item**, a simpler entry with just a title, ID, description, and category
- Create a **Category** with a title and ID (defaults to Home/Work, plus any custom categories)
- Mark items as completed or remove them from the list
- Save the current list to a text file and load it back later

## Project structure

```
.
├── Program.cs              # CLI app entry point and logic
├── ToDoAppCLI.csproj        # CLI project file
├── ToDoAppCLI.sln           # Solution file
├── GUI/                     # WPF desktop app
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   └── GUI.csproj
├── Domain Model.png         # Rough domain model diagram
├── Dockerfile                # Container build for the CLI app
└── .dockerignore
```

## Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- Docker (optional, only needed to run the CLI app in a container)
- Windows (only needed to build or run the GUI app, since it uses WPF)

## Running the CLI locally

From the repo root:

```bash
dotnet run --project ToDoAppCLI.csproj
```

This starts an interactive menu in the terminal. Follow the on-screen prompts to add tasks, remove tasks, list tasks, or add categories.

## Running the GUI locally

The GUI app targets `net7.0-windows` and uses WPF, so it can only be built and run on Windows:

```bash
dotnet run --project GUI/GUI.csproj
```

## Running the CLI with Docker

The GUI cannot run in a container since WPF needs a Windows desktop to render. Docker support here covers the CLI app only.

Build the image from the repo root:

```bash
docker build -t todo-cli .
```

Run it interactively (the `-it` flag is required since the app reads input from the terminal):

```bash
docker run -it todo-cli
```

## Notes

This project was built for practice and portfolio purposes. There is no automated test suite, and the CLI and GUI apps do not share code, they are two independent implementations of a similar idea. Some rough edges (validation, error handling, styling) were left as-is to keep the project representative of an early-stage learning project rather than a finished product.
