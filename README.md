# **EShop Microservices Project**

The project is composed of multiple microservices, each with its own specific purpose to ensure a scalable and efficient e-commerce solution.

---

## **Catalog Microservice**
A fast and efficient service built with .NET 8 and C# 12, featuring:

- **ASP.NET Core Minimal APIs:** For handling HTTP requests quickly.
- **Vertical Slice Architecture:** Everything organized by features.
- **CQRS Pattern:** Using MediatR to separate read and write operations.
- **FluentValidation:** Keeps input validation clean and simple.
- **Marten:** Stores data in PostgreSQL as documents.
- **Carter:** Easily defines Minimal API endpoints.

### **Extras:**
- Logging
- Global error handling
- Health checks
- **Docker:** Fully containerized for easy multi-service setups.

---

## **Basket Microservice**
A practical service designed with .NET 8 for managing shopping baskets, featuring:

- **ASP.NET Core 8 Web API:** Built with REST principles to handle basic CRUD operations.
- **Redis:** Uses Redis as a distributed cache (`basketdb`) to keep things fast and scalable.
- **Design Patterns:** Implements Proxy, Decorator, and Cache-aside patterns for a clean, organized structure.
- **gRPC:** Connects to the Discount gRPC Service to calculate product prices across services.
- **Messaging:** Sends `BasketCheckout` messages to RabbitMQ queues with MassTransit for reliable workflows.

### **Architecture:**
- **Repository Pattern**
- **CQRS (Command Query Responsibility Segregation)**
- **Mediator Pattern**
- **Minimal APIs:** Keeps things straightforward.

---
## **Discount Microservice**
A high-performance gRPC service built with .NET 8 for managing product discounts.

### **Core Features:**
- **ASP.NET Core gRPC Service:** Optimized for inter-service discount calculations with the Basket Microservice.
- **Protobuf Messages:** Exposes gRPC services by defining structured communication messages.
- **Entity Framework Core ORM:** Utilizes SQLite as the data provider with full support for database migrations.
- **SQLite Database Connection:** Supports seamless containerization for deployment.

### **Extras:**
- Logging
- Global error handling
- Health checks
- Automated database migrations on startup
- **Docker:** Fully containerized for smooth integration


