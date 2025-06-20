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

- Add new Todo tasks
- Edit existing tasks
- Mark tasks as complete / incomplete
- Delete tasks
- Display tasks with filtering (show all / active / completed)
- Store data persistently in SQLite database
- Responsive web interface using Razor Views (Bootstrap 5 optional)

---

## 🛠️ Technologies Used

| Component              | Technology                  |
|------------------------|----------------------------|
| Framework              | .NET 8 SDK                  |
| Backend                | ASP.NET Core MVC            |
| Database               | SQLite                      |
| ORM                    | Entity Framework Core       |
| Dependency Injection   | Built-in .NET Core DI       |
| Views / Frontend       | Razor Views + Bootstrap 5   |
| Development Tools      | Visual Studio 2022 / VSCode |

---

## 🏗️ Architecture

Controller → Service → Repository → Database  
Models → ViewModels → Views

---

## 📂 Project Structure

```text
TodoListApp/                  --> Project Root  
 ├── Controllers/             --> MVC Controllers  
 ├── Models/                  --> Entity Models (EF Core)  
 ├── Services/                --> Business logic layer  
 ├── Repositories/            --> Data access layer  
 ├── Views/                   --> Razor views (UI)  
 ├── wwwroot/                 --> Static files (CSS, JS)  
 ├── appsettings.json         --> App configuration  
 ├── Program.cs               --> Application entry point  
 └── TodoListApp.csproj       --> Project file  
