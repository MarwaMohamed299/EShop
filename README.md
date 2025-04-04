**E-Commerce Microservices Project**  

This project is a fully functional **e-commerce system** built using **.NET microservices**. The objective was to develop a **scalable, maintainable, and high-performance** system by leveraging modern technologies, including **ASP.NET Web API, Docker, RabbitMQ, MassTransit, gRPC, YARP API Gateway, PostgreSQL, Redis, SQLite, SQL Server, and Marten**.  

The architecture consists of multiple microservices—**Product, Basket, Discount, and Ordering**—that communicate through **RabbitMQ** for event-driven interactions. **YARP API Gateway** is utilized to efficiently manage API requests. The system integrates both **NoSQL** (PostgreSQL DocumentDB, Redis) and **relational databases** (SQLite, SQL Server) for optimized data handling.  

---

## **Microservices & Core Functionalities**  

### **Catalog Microservice**  
- Developed using **ASP.NET Core Minimal APIs** with the latest **.NET 8** features.  
- Implements **Vertical Slice Architecture** for a structured, feature-based approach.  
- Follows the **CQRS pattern with MediatR** to separate read and write concerns.  
- Uses **Marten with PostgreSQL** for document-based data storage.  
- Employs **FluentValidation** to enforce request validation.  
- Fully **Dockerized** for streamlined deployment.  

### **Basket Microservice**  
- Built as a **RESTful API** using **ASP.NET 8**.  
- Uses **Redis** for distributed caching to enhance performance.  
- Implements **Proxy, Decorator, and Cache-aside** patterns for efficiency.  
- Communicates with the **Discount gRPC service** to apply dynamic pricing.  
- Publishes **BasketCheckout events** via **RabbitMQ and MassTransit** for asynchronous processing.  

### **Discount Microservice**  
- Designed as a **high-performance gRPC service**.  
- Uses **Protobuf** for efficient inter-service communication.  
- Stores discount data in **SQLite with Entity Framework Core**.  
- Fully containerized for ease of deployment.  

### **Ordering Microservice**  
- Implements **Domain-Driven Design (DDD), CQRS, and Clean Architecture**.  
- Uses **MediatR, FluentValidation, and Mapster** for structured request handling.  
- Manages order processing through **RabbitMQ-based event-driven messaging**.  
- Uses **SQL Server with Entity Framework Core** for order storage and transactions.  

---

## **API Gateway (YARP)**  
- Configured **YARP Reverse Proxy** for efficient API routing and management.  
- Implements **route configurations, clusters, and request transformations**.  
- Supports **rate limiting** to control traffic and ensure system stability.  

---

## **WebUI ShoppingApp**  
- Developed with **ASP.NET Core Razor views and Bootstrap** for an intuitive UI.  
- Uses **Refit and HttpClientFactory** for API communication.  
- Leverages **Razor features such as View Components and Tag Helpers** for modularity.  

---

## **Microservices Communication**  
- **Synchronous** communication via **gRPC** for low-latency service interactions.  
- **Asynchronous** messaging via **RabbitMQ and MassTransit** for event-driven workflows.  
- Implements a **Publish/Subscribe model** for distributed processing.  

---

## **Docker & Containerization**  
- Utilizes **Docker Compose** to orchestrate all microservices seamlessly.  
- Includes **databases, distributed caching, and message brokers** for a complete ecosystem.  
- Configured with **environment variables** for flexible and customizable deployments.  

---

