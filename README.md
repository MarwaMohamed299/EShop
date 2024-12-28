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
