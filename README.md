# EShop

The project is made up of multiple microservices, each with its own purpose.

Catalog Microservice

A fast and efficient service built with .NET 8 and C# 12, featuring:

ASP.NET Core Minimal APIs for handling HTTP requests quickly.

Vertical Slice Architecture with everything organized by features.

CQRS Pattern using MediatR to separate read and write operations.

FluentValidation to keep input validation clean and simple.

Marten for storing data in PostgreSQL as documents.

Carter to easily define Minimal API endpoints.

Extras:

Logging

Global error handling

Health checks

Docker: Fully containerized for easy multi-service setups.

Basket Microservice

A practical service designed with .NET 8 for managing shopping baskets, featuring:

ASP.NET Core 8 Web API: Built with REST principles to handle basic CRUD operations.

Redis: Uses Redis as a distributed cache (basketdb) to keep things fast and scalable.

Design Patterns: Includes Proxy, Decorator, and Cache-aside for a clean, organized structure.

gRPC: Connects to the Discount gRPC Service to calculate product prices across services.

Messaging: Sends BasketCheckout messages to RabbitMQ queues with MassTransit for reliable workflows.

Architecture: Built with Vertical Slice Architecture, including:

Repository Pattern

CQRS (Command Query Responsibility Segregation)

Mediator Pattern

Minimal APIs to keep things straightforward.

