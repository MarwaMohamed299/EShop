# EShop

The project is made up of multiple microservices, each with its own purpose.

---

## **Catalog Microservice**
A fast and efficient service built with .NET 8 and C# 12, featuring:

- **ASP.NET Core Minimal APIs**: For handling HTTP requests quickly.
- **Vertical Slice Architecture**: Everything organized by features.
- **CQRS Pattern**: Using MediatR to separate read and write operations.
- **FluentValidation**: To keep input validation clean and simple.
- **Marten**: For storing data in PostgreSQL as documents.
- **Carter**: To easily define Minimal API endpoints.

### **Extras**
- Logging
- Global error handling
- Health checks
- **Docker**: Fully containerized for easy multi-service setups.

---

## **Basket Microservice**
A practical service designed with .NET 8 for managing shopping baskets, featuring:

- **ASP.NET Core 8 Web API**: Built with REST principles to handle basic CRUD operations.
- **Redis**: Uses Redis as a distributed cache (`basketdb`) to keep things fast and scalable.
- **Design Patterns**: Includes Proxy, Decorator, and Cache-aside for a clean, organized structure.
- **gRPC**: Connects to the Discount gRPC Service to calculate product prices across services.
- **Messaging**: Sends `BasketCheckout` messages to RabbitMQ queues with MassTransit for reliable workflows.

### **Architecture**
- **Repository Pattern**
- **CQRS** (Command Query Responsibility Segregation)
- **Mediator Pattern**
- **Minimal APIs**: To keep things straightforward.



