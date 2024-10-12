# 📦 InventoryHub 

This project contains a sample ASP.NET Core app. This app is an example of the article I produced for the Telerik Blog (telerik.com/blogs)

An ASP.NET Core application for managing inventory systems, built with SQL Server and Entity Framework (EF) Core.

## 🌟 Key Features

- **ASP.NET Core** - A robust and flexible web framework for building modern web apps.
- **SQL Server** - Reliable and powerful database management system.
- **Entity Framework Core** - ORM (Object-Relational Mapping) for streamlined database access.
- **Scaffolding from Visual Studio** - Automatic code generation for CRUD operations.

## 🛠️ Setup & Installation

### 1. Clone the repository
```bash
git clone https://github.com/zangassis/inventory-hub.git
```

### 2. Open the project in Visual Studio

Simply launch Visual Studio and open the `.sln` file from the root of the project.

### 3. Configure the SQL Server connection string

Go to the `appsettings.json` file and set the connection string for your SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server_name;Database=InventoryHubDB;Trusted_Connection=True;"
}
```

### 4. Apply Database Migrations
Run the following commands in the **Package Manager Console** to update the database schema using EF Core migrations:
```bash
Update-Database
```

### 5. Run the Application
Press `F5` or click the **Run** button in Visual Studio to start the application. 🚀

## 🏗️ Project Structure

- **Controllers**: Handles incoming requests and returns appropriate responses.
- **Entities**: Defines the data structure used in the app and corresponds to the database entities.
- **Data**: Contains the database context (EF Core) and manages migrations.

## 🛠️ Features

- **CRUD Operations**: Effortless creation, reading, updating, and deleting of inventory items.
- **Scaffolding**: Code generation for controllers, views, and models using Visual Studio tools.

## 📚 Requirements

- **.NET 6 SDK** or later
- **SQL Server** (Local or Remote)
- **Visual Studio 2022** (or later)

## ✨ Getting Started

1. **Clone the repository** to your local machine.
2. **Configure the database** connection in `appsettings.json`.
3. **Run database migrations** to set up the tables.
4. Start managing your inventory with **InventoryHub**! 🛒
