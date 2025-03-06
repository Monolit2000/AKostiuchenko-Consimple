# DigitalStore.API
Solution test task

## Overview

This project implements a web service for managing store data, developed on the .NET platform using C#. It provides a Web API for interacting with clients, products, and purchases, along with a simple interface for testing via Swagger. The solution is designed to handle store-related operations efficiently and includes seed data for immediate testing.

## Architecture

The system follows **Vertical Slice Architecture**, which organizes code by features rather than traditional layers. This approach enhances modularity, maintainability, and scalability by grouping all related logic (queries, handlers, controllers, DTOs) into feature-specific slices. The architecture is enhanced with the **MediatR** library to decouple request handling and improve testability.

### Core Components:

- **Features**: Each feature (e.g., Birthdays, RecentPurchases, PopularCategories) contains its own queries, handlers, and DTOs.
- **Models**: Defines core entities (Client, Product, Purchase, PurchaseItem) representing the business domain.
- **Data**: Includes the database context (`StoreDbContext`) and seed data (`StoreDbContextSeed`) for initialization.
- **Infrastructure**: Manages external dependencies like PostgreSQL via EF Core.

The solution is implemented using .NET (compatible with .NET 8) with the following structure:

```plaintext
DigitalStore.API/
├── Controllers/
│   ├── StoreController.cs
├── Data/
│   ├── MigrationExtensions.cs
│   ├── StoreDbContext.cs
│   ├── StoreDbContextSeed.cs
├── Features/
│   ├── Clients/
│   │   ├── GetBirthdays/
│   │   │   ├── GetBirthdaysQuery.cs
│   │   │   ├── GetBirthdaysHandler.cs
│   │   │   └── ClientBirthdayDto.cs
│   ├── Purchases/
│   │   ├── GetRecentPurchases/
│   │   │   ├── GetRecentPurchasesQuery.cs
│   │   │   ├── GetRecentPurchasesHandler.cs
│   │   │   └── RecentPurchaseDto.cs
│   ├── Products/
│   │   ├── GetPopularCategories/
│   │   │   ├── GetPopularCategoriesQuery.cs
│   │   │   ├── GetPopularCategoriesHandler.cs
│   │   │   └── PopularCategoryDto.cs
├── Models/
│   ├── Client.cs
│   ├── Product.cs
│   ├── Purchase.cs
│   └── PurchaseItem.cs
├── Program.cs
├── appsettings.json
```

## Features

### 1. **Client Birthday Management**

* **Get Birthday List**: Retrieves a list of clients whose birthday matches the specified date (day and month only).
  - **Endpoint**: `GET /api/GetBirthdays/client/getBirthdaysList/?date={date}`
  - **Examples**: `?date=1990-03-05`, `?date=1995-04-15`, `?date=1992-12-25`

### 2. **Purchase Management**

* **Get Recent Purchasers**: Fetches clients who made purchases within the last N days, including their most recent purchase date.
  - **Endpoint**: `GET /api/recent-purchases?days={days}`
  - **Example**: `?days=7`
 
### 3. **Product Management**    
* **Get Popular Categories**: Returns product categories purchased by a specific client with the total quantity of items per category.
  - **Endpoint**: `GET /api/popular-categories/{clientId}`
  - **Example**: `/api/popular-categories/1`


## Setup 

### How to Run with Docker Compose

1. Clone the repository:
 
   ```bash
   git clone <repository-url>
   ```

2. Build and Run with Docker Compose
   ```bash
   docker-compose up 
   ```
