# EShop
The project consists of multiple microservices, each serving a distinct purpose.

Below is the description of the Catalog Microservice:

A high-performance microservice built with .NET 8 and C# 12, featuring:
ASP.NET Core Minimal APIs for efficient HTTP request handling.
Vertical Slice Architecture organized by feature folders.
CQRS Pattern implemented with MediatR, along with FluentValidation for pipeline validation.
Marten for transactional document storage in PostgreSQL.
Carter for modular Minimal API endpoint definitions.
Cross-Cutting Concerns such as logging, global exception handling, and health checks.
Containerization with Docker for multi-container setups.
