# 📚 Book Management Web API (ASP.NET Core + Docker)

A RESTful **Book Management Web API** built with **ASP.NET Core Web API**, **JWT Bearer Authentication**, **SQL Server**, and fully containerized using **Docker & Docker Compose**.

This project is part of my backend learning journey, focusing on:

* Authentication & Authorization
* Clean architecture (Controllers, Services, DTOs)
* Database-driven APIs
* Dockerized development environment

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red.svg)](https://www.microsoft.com/sql-server)
[![JWT](https://img.shields.io/badge/Auth-JWT-green.svg)](https://jwt.io/)
[![Docker](https://img.shields.io/badge/Docker-Enabled-blue.svg)](https://www.docker.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

 

## 🚀 Features

* JWT Bearer Authentication
* Secure endpoints using `[Authorize]`
* Login endpoint to generate JWT token
* Full CRUD operations for Books
* SQL Server database with EF Core Migrations
* Service layer abstraction (`IBookService`, `IAuthService`)
* Dockerized API and database using Docker Compose
* Swagger API documentation

 
## 🛠️ Technologies

* **ASP.NET Core Web API (.NET 8)**
* **Entity Framework Core**
* **SQL Server**
* **JWT Bearer Authentication**
* **Docker & Docker Compose**
* **Swagger / OpenAPI**
* **AutoMapper**
* **Dependency Injection**

 
## 🔐 Authentication

This API uses **JWT Bearer Authentication**.

### Login Endpoint

```http
POST /api/Auth/login
```

**Request Body:**

```json
{
  "username": "admin",
  "password": "1234"
}
```

**Response:**

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

Use this token in requests:

```http
Authorization: Bearer YOUR_TOKEN
```


## 📘 Book Endpoints (Protected)

All book endpoints require a valid JWT token.

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | `/api/Book` | Get all books |
| GET    | `/api/Book/{id}` | Get book by id |
| POST   | `/api/Book/create` | Create a new book |
| PUT    | `/api/Book/update/{id}` | Update a book |
| DELETE | `/api/Book/delete/{id}` | Delete a book |


### Example Create Book Request

```json
{
  "title": "Clean Code"
}
```

![book management api swagger](https://github.com/user-attachments/assets/3ad98460-39a6-4af2-9d5e-6e0a7d8db206)

## 🐳 Docker & Docker Compose Setup

This project is fully containerized.
It runs using **docker-compose** (API + SQL Server).

### Prerequisites

* Docker
* Docker Compose

### Run the project

1. Clone the repository:

```bash
git clone https://github.com/Alireza-Jafari-tech/Book-Management-Web-API.git
cd Book-Management-Web-API
```

2. Create `.env` file (already included in repo or customize it):

```env
DB_NAME=BookJwtAppDb
SA_PASSWORD=YourStrong!Passw0rd
JWT_SECRET=YourSecretKey
```

3. Run with Docker Compose:

```bash
docker compose up --build
```

4. Open Swagger UI:

```
http://localhost:5000/swagger
```

 
## ⚙️ Local Setup (Without Docker)

1. Update connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BookJwtAppDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

2. Apply migrations:

```bash
dotnet ef database update
```

3. Run the application:

```bash
dotnet run
```


## 📂 Project Structure

```pgsql
Book-Management-Web-API
 ┣ Controllers
 ┃ ┣ AuthController.cs
 ┃ ┗ BookController.cs
 ┣ Services
 ┃ ┣ AuthService.cs
 ┃ ┗ BookService.cs
 ┣ Interfaces
 ┃ ┣ IAuthService.cs
 ┃ ┗ IBookService.cs
 ┣ DTOs
 ┃ ┣ BookDto.cs
 ┃ ┣ BookCreateDto.cs
 ┃ ┣ BookUpdateDto.cs
 ┃ ┗ LoginDto.cs
 ┣ Models
 ┃ ┗ Book.cs
 ┣ Data
 ┃ ┗ AppDbContext.cs
 ┣ Profiles
 ┃ ┗ MappingProfiles.cs
 ┣ Migrations
 ┣ Dockerfile
 ┣ docker-compose.yml
 ┣ .env
 ┣ Program.cs
 ┗ README.md
```

 
## 🎯 Learning Goals

* Build RESTful APIs with ASP.NET Core
* Implement JWT authentication and authorization
* Apply clean architecture (Controllers → Services → Data)
* Use DTOs and AutoMapper
* Work with SQL Server and EF Core migrations
* Dockerize a .NET Web API
* Use Docker Compose for multi-container apps
* Test APIs with Swagger and Postman

 

## 🧑‍💻 Usage

* Call `/api/Auth/login` to get a JWT token
* Use the token in Authorization header
* Perform CRUD operations on `/api/Book`
* Explore endpoints using Swagger UI

 

## 📝 License

This project is licensed under the MIT License.
See the LICENSE file for details.

 

## 🤝 Contributing

This project is for learning purposes, but feel free to fork and improve it.
Suggestions and pull requests are welcome!
