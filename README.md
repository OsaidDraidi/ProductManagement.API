# ProductManagement.API

A clean and modular ASP.NET Core Web API for managing products with authentication and authorization using JWT and Identity.

---

##  Features

-  Register / Login functionality with JWT authentication
-  Role-based access control using ASP.NET Core Identity
-  Manage Products (CRUD)
-  DTOs and AutoMapper for clean data transfer
-  Repository & Service Layer architecture
-  Secure endpoints with role-based protection
-  Token generation with Claims and Roles

---

##  Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- ASP.NET Core Identity
- JWT (JSON Web Tokens)
- Swagger (for API documentation)

---

##  Project Structure
ProductManagement.API/
|
├── Controllers/ # API Controllers
├── DTOs/ # Data Transfer Objects
├── Models/ # Application Models (e.g., ApplicationUser, Product)
├── Repositories/ # Repository layer (Interfaces + Implementations)
├── Services/ # Service layer (Interfaces + Implementations)
├── Mappings/ # AutoMapper Profiles
├── appsettings.json # Configuration (e.g., DB connection, JWT)
└── Program.cs & Startup.cs # App Configuration & Dependency Injection