# Aspire-Powered Todo List

A modernized, distributed Todo List application built using **.NET 8** and orchestrated with **.NET Aspire**. This project transforms a traditional ASP.NET Core MVC application into a multi-service solution, showcasing how Aspire simplifies local development, service discovery, and observability for cloud-native applications.

---

## 📚 Project Description

This solution is designed to demonstrate:

* **Decomposition with .NET Aspire:** How a monolithic ASP.NET Core MVC application can be logically separated into distinct UI and API services.

* **Service Orchestration:** Leveraging .NET Aspire's `AppHost` to manage and run multiple interconnected services (UI, API, Database) from a single entry point.

* **Service Discovery:** How the frontend (MVC) can seamlessly communicate with the backend (Web API) using Aspire's built-in service discovery, eliminating hardcoded URLs.

* **Containerized Databases:** Using Aspire to automatically provision and manage a local PostgreSQL (or SQL Server) database instance via Docker for development.

* **Observability:** Utilizing the Aspire Dashboard for centralized logging, tracing, and health monitoring across all services.

* **Clean Architecture Principles:** Maintaining separation of concerns, with clear responsibilities for each layer (Controller, Service, Repository, Database).

* **Core ASP.NET Features:** Continues to use familiar patterns like MVC, Dependency Injection, and Entity Framework Core.

---

## 🚀 Features

* **Task Management:** Add, view, edit, mark complete/incomplete, and delete Todo tasks.

* **Data Persistence:** Tasks are stored in a relational database (PostgreSQL/SQLite).

* **Distributed Architecture:** Separated frontend and backend services for improved scalability and maintainability.

* **Aspire Dashboard Integration:** Real-time insights into application health and network interactions.

---

## 🛠️ Technologies Used

* **Platform:** .NET 8 SDK

* **Orchestration:** .NET Aspire

* **Frontend:** ASP.NET Core MVC (Razor Views)

* **Backend:** ASP.NET Core Web API

* **Database:** PostgreSQL (or SQL Server, managed by Aspire with Docker)

* **ORM:** Entity Framework Core

* **Dependency Management:** Built-in .NET Core Dependency Injection

* **Development Tools:** Visual Studio 2022 (v17.8+), VS Code with C# Dev Kit, Docker Desktop

---

## 🏗️ Architecture

The solution is structured into several projects, orchestrated by .NET Aspire:

```mermaid
graph TD
    A[AspireTodoApp.AppHost] --> B(AspireTodoApp.Web - Frontend UI);
    A --> C(AspireTodoApp.ApiService - Backend API);
    A --> D(PostgreSQL/SQL Server - Database Container);
    B -- HTTP Calls --> C;
    C -- EF Core --> D;
    B -. Service Discovery .- C;
    A -. Manages & Observes .-> B;
    A -. Manages & Observes .-> C;
    A -. Manages & Observes .-> D;