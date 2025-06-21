# 💰 WalletApp API

A secure, token-based Web API built with ASP.NET Core that manages user authentication, transactions, and budgeting. Designed for financial tracking with JWT-based authentication and CORS support for integration with frontend clients.

## 📌 Features

- 🔐 User Registration & Login (JWT Token Authentication)
- 💸 Create, Read, Update, Delete Transactions
- 🧾 Budget Management
- 🧪 Protected API endpoints with token validation
- 🌐 CORS Enabled for Cross-Origin Requests
- 🧪 Swagger API UI

## 🛠️ Technologies Used

- ASP.NET Core Web API (.NET 9)
- Entity Framework Core
- Microsoft IdentityModel.Tokens (JWT)
- Swagger/OpenAPI
- CORS Middleware
- SQLite (or your configured DB provider)

## 🚀 Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- Git

### Clone & Run
```bash
git clone https://github.com/YourUsername/WalletApp-API.git
cd WalletApp
dotnet restore
dotnet run --project WalletApp.API
