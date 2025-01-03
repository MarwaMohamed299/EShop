# EShop

The project consists of multiple microservices, each serving a distinct purpose.

### **Catalog Microservice**
A high-performance microservice built with .NET 8 and C# 12, featuring:

- **ASP.NET Core Minimal APIs** for efficient HTTP request handling.  
- **Vertical Slice Architecture** organized by feature folders.  
- **CQRS Pattern** implemented with MediatR.  
- **FluentValidation** for pipeline validation.  
- **Marten** for transactional document storage in PostgreSQL.  
- **Carter** for modular Minimal API endpoint definitions.  
- **Cross-Cutting Concerns**:  
  - Logging  
  - Global exception handling  
  - Health checks  
- **Containerization** using Docker for multi-container setups.

### **Basket Microservice**
A robust microservice designed with .NET 8, focusing on seamless basket management, featuring:

- **ASP.NET Core 8 Web API**: Developed following RESTful principles, supporting CRUD operations.  
- **Redis Integration**: Leveraging Redis as a distributed cache, utilizing `basketdb` for enhanced performance and scalability.  
- **Design Patterns**: Implements Proxy, Decorator, and Cache-aside patterns to ensure clean, maintainable architecture.  
- **gRPC Communication**: Consumes the Discount gRPC Service to enable inter-service communication for calculating the final price of products.  
- **Messaging System**: Publishes `BasketCheckout` messages to a RabbitMQ queue using MassTransit for reliable, message-driven workflows.  
- **Architecture**: Designed with Vertical Slice Architecture, including:  
  - Repository Pattern  
  - CQRS (Command Query Responsibility Segregation)  
  - Mediator Pattern  
  - Minimal APIs for concise and focused endpoints.

