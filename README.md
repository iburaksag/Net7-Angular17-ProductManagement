## Overview

ProductManagement is a full-stack application that combines a .NET Core 7 Minimal API for backend services and an Angular 17 frontend for an interactive user interface. The API allows you to manage two domains: Products and Categories. The backend follows the principles of Clean Architecture and implements the Generic Repository Pattern for data access. Data is stored in a MongoDB NoSQL database, providing a flexible and scalable solution for your application.

## Features

- **CRUD Functionality**: Provides Create, Read, Update, and Delete operations for both Products and Categories.
- **Clean Architecture**: Project structured according to Clean Architecture principles for maintainability and scalability.
- **Generic Repository Pattern**: Utilizes the Generic Repository Pattern for consistent data access across different domains.
- **Minimal API**: Developed with Minimal API, a lightweight approach for building APIs with minimal ceremony.
- **MongoDB Integration**: Stores data in a MongoDB NoSQL database for efficient and scalable data storage. MongoDB.Driver is used to connect the project to the MongoDB Cluster.
- **Angular 17 UI**: The client-side of the application is developed with Angular 17, providing a modern and responsive user interface.

## Technologies Used

- .NET Core 7
- MongoDB
- Clean Architecture
- Generic Repository Pattern
- Minimal API
- Angular 17

## Getting Started

Follow these steps to get started with ProductManagement:

1. Clone the repository.
2. Configure your MongoDB connection in the app settings.
3. Build and run the application.

For the Angular UI:

1. Navigate to the 'ProductManagement.UI' directory.
2. Install dependencies using `npm install`.
3. Run the Angular application with `ng serve -o`.

The application will be accessible at `http://localhost:4200`.

## Making API Calls from Angular

The Angular UI communicates with the .NET Core API to perform CRUD operations. API endpoints are prefixed with `/api/v1/`. Update the Angular service files to point to the appropriate API endpoints for seamless integration.

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
