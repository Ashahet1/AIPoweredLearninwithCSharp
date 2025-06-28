# 📝 Todo List Web App — ASP.NET Core MVC

A simple web-based Todo List application built using **ASP.NET Core MVC**.
It allows users to manage their tasks (create, view, update, delete) using a clean architecture approach.

---

## 📚 Project Description

This project demonstrates:

- The **Model-View-Controller (MVC)** pattern in ASP.NET Core
- **Clean separation of concerns**: Controller → Service → Repository → Database
- **Dependency Injection** — built-in .NET Core feature
- **Entity Framework Core** — for database operations
- **SQLite** — lightweight, file-based database

This is a foundational project for developers who want to learn how to structure a simple web app in C#/.NET.

---

## 🚀 Features

- Add new Todo tasks (with optional notes)
- Edit existing tasks
- Mark tasks as complete / incomplete
- Delete tasks
- Store data persistently in SQLite database
- Responsive web interface using Razor Views

---

## 🛠️ Technologies Used

| Component | Technology |
|---|---|
| Framework | .NET 8 SDK |
| Backend | ASP.NET Core MVC |
| Database | SQLite |
| ORM | Entity Framework Core |
| Dependency Injection | Built-in .NET Core DI |
| Views / Frontend | Razor Views |
| Development Tools | Visual Studio / VSCode |

---

## 🏗️ Architecture

Controller → Service → Repository → Database
Models → ViewModels (if applicable) → Views

---

## 📂 Project Structure

```text
TodoListApp/
 ├── Controllers/             --> MVC Controllers (e.g., TodoController.cs)
 ├── Data/                    --> Database Context (AppDbContext.cs, AppDbContextFactory.cs)
 ├── Models/                  --> Entity Models (e.g., TodoItem.cs)
 ├── Services/                --> (Optional: For more complex business logic)
 ├── Repositories/            --> (Optional: For abstracting data access)
 ├── Views/                   --> Razor views (UI: Index.cshtml, Create.cshtml, Edit.cshtml, Delete.cshtml, _ViewImports.cshtml)
 │   ├── Shared/              --> Shared views (e.g., _Layout.cshtml)
 │   └── Todo/                --> Views specific to TodoController
 ├── wwwroot/                 --> Static files (CSS, JS)
 ├── appsettings.json         --> Application configuration
 ├── Program.cs               --> Application entry point (or Startup.cs in older versions)
 └── TodoListApp.csproj       --> Project file
