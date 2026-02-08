\# TaskManager API


Production-ready Task Management REST API built with ASP.NET Core.


\## 🚀 Live Demo

https://taskmanager-production-b481.up.railway.app


\## 🛠 Tech Stack

\- ASP.NET Core Web API (.NET 8)

\- Entity Framework Core

\- SQL Server

\- JWT Authentication

\- Docker

\- Railway (Cloud Deployment)

\- Swagger (Development only)



\## 🔐 Features

\- User Authentication (JWT)

\- Role-based Authorization (Admin / User)

\- Task ownership (users can access only their own data)

\- Pagination

\- Global Exception Handling

\- HealthChecks (`/health`)



\## 📦 Run Locally



```bash

git clone https://github.com/Ganiev96/TaskManager.git

cd TaskManager

dotnet restore

dotnet run ```


Swagger (Development only):
http://localhost:7115/swagger


## ❤️ Health Check
Production:
https://taskmanager-production-b481.up.railway.app/health

