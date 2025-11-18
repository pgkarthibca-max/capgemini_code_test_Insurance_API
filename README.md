# 💼 Insurance Premium Calculator

A full-stack web application to calculate **monthly insurance premiums** based on a member’s personal details and occupation.  
Built with **React (frontend)**, **.NET Core Web API (backend)**, and **PostgreSQL (database)**.

---

## 🧠 Project Overview

### 🎯 User Story
> As a member, I want to enter my details and select an occupation,  
> so that I can view my monthly insurance premium calculated instantly.

### 💡 Premium Formula
Monthly Premium = (Death Sum Insured * Rating Factor * Age) / 1000 * 12


---

## ⚙️ Tech Stack

| Layer | Technology |
|-------|-------------|
| **Frontend** | React (with Axios, Tailwind CSS) |
| **Backend** | .NET 8 / .NET Core Web API |
| **Database** | PostgreSQL |
| **ORM** | Entity Framework Core |
| **Language** | C#, JavaScript (ES6) |

---

## 🗄️ Database Design

### **Entity Relationship Diagram**

────────────────────────────┐
│ Occupations │
├────────────────────────────┤
│ Id (PK) │
│ OccupationName │
│ Rating │
│ RatingFactor │
└───────────────┬────────────┘
│
│ 1 ────── *
▼
┌────────────────────────────┐
│ Members │
├────────────────────────────┤
│ Id (PK) │
│ Name │
│ AgeNextBirthday │
│ DateOfBirth │
│ OccupationId (FK) │
│ DeathSumInsured │
│ MonthlyPremium │
└────────────────────────────┘


---

## 🧩 API Endpoints

| Method | Endpoint | Description |
|--------|-----------|-------------|
| `GET` | `/api/premium/occupations` | Fetch all available occupations |
| `POST` | `/api/premium/calculate` | Calculate and save monthly premium |

### Example Request

```json
POST /api/premium/calculate
{
  "name": "John Doe",
  "ageNextBirthday": 35,
  "dateOfBirth": "1990-05-01",
  "occupationId": 2,
  "deathSumInsured": 500000
}


{
  "monthlyPremium": 315000
}


### Backend Setup (.NET Core)
cd InsuranceApi
dotnet restore
dotnet ef database update
dotnet run

### Connection String

Edit in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=InsuranceDB;Username=postgres;Password=yourpassword"
}

### Frontend Setup (React)
cd insurance-ui
npm install
npm start


## Additional Design Patterns Added

Per your request, I replaced and extended several parts of the project with common enterprise design patterns: **Factory**, **Repository**, **Unit of Work**, and a minimal **Dependency Injection** container. These are implemented in a lightweight manner so you can run the project without external DI libraries.

### What I added (high level)

1. **Factory**
   - `IOccupationRatingProvider` - abstraction to resolve occupation -> rating and factor.
   - `OccupationRatingFactory` - concrete factory implementing the mapping logic.

2. **Repository + Unit of Work (EF-based)**
   - `IRepository<T>` / `EfRepository<T>` - generic repository for CRUD operations.
   - `IUnitOfWork` / `EfUnitOfWork` - transaction boundary and commit handling.
   - `PremiumDbContext` - EF `DbContext` with `DbSet<MemberPremium>`.
   - `MemberPremium` entity mapping matching suggested DB schema.

3. **Dependency Injection (lightweight)**
   - `IServiceRegistry` and `ServiceContainer` - a tiny DI container to register singletons/transients and resolve by type.
   - `Bootstrapper` (or `Global.asax` wiring example) to register services at app start.

4. **Refactoring Controllers & Services**
   - Controllers (Web API) now receive dependencies (calculator service, occupation provider, unit of work) via constructor injection.
   - A `PremiumCalculatorService` implements business logic using the strategy and repository patterns and persists calculated results via UnitOfWork.


