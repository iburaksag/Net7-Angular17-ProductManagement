# Project Name

ProductManagementAPI - Manage Products and Categories

## Overview

ProductManagementAPI is a .NET Core 7 Minimal API that allows you to manage two domains: Products and Categories. The API follows the principles of Clean Architecture and implements the Generic Repository Pattern for data access. Data is stored in a MongoDB NoSQL database, providing a flexible and scalable solution for your application.

## Features

- **CRUD Functionality**: Provides Create, Read, Update, and Delete operations for both Products and Categories.
- **Clean Architecture**: Project structured according to Clean Architecture principles for maintainability and scalability.
- **Generic Repository Pattern**: Utilizes the Generic Repository Pattern for consistent data access across different domains.
- **Minimal API**: Developed with Minimal API, a lightweight approach for building APIs with minimal ceremony.
- **MongoDB Integration**: Stores data in a MongoDB NoSQL database for efficient and scalable data storage. MongoDB.Driver is used to connect project to MongoDB Cluster.

## Technologies Used

- .NET Core 7
- MongoDB
- Clean Architecture
- Generic Repository Pattern
- Minimal API

## Getting Started

Follow these steps to get started with ProductManagementAPI:

1. Clone the repository.
2. Configure your MongoDB connection in the app settings.
3. Build and run the application.

## API Endpoints

The API exposes the following endpoints:

- **Products**
  - `GET /api/v1/products`: Retrieve all products.
  - `GET /api/v1/products/{id}`: Retrieve a specific product by ID.
  - `GET /api/v1/products/category/{id}`: Retrieve a specific product by category ID.
  - `POST /api/v1/products`: Create a new product.
  - `PUT /api/v1/products/{id}`: Update an existing product.
  - `DELETE /api/v1/products/{id}`: Delete a product.

- **Categories**
  - `GET /api/v1/categories`: Retrieve all categories.
  - `GET /api/v1/categories/{id}`: Retrieve a specific category by ID.
  - `POST /api/v1/categories`: Create a new category.
  - `PUT /api/v1/categories/{id}`: Update an existing category.
  - `DELETE /api/v1/categories/{id}`: Delete a category.
