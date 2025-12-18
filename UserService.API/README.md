# UserService.API

Microservicio de autenticación y gestión de usuarios para LKPainter.

Responsabilidades:
- Registro y login de usuarios
- Autenticación basada en ASP.NET Core Identity
- Generación y validación de JWT
- Gestión de roles (User / Admin)
- Perfil de usuario (`/api/users/me`)
- Protección de endpoints por roles
- Manejo global de excepciones
- Validación de DTOs con FluentValidation

Tecnologías:
ASP.NET Core · Entity Framework Core · Identity · JWT · SQL Server

Este servicio actúa como proveedor central de identidad para el resto del sistema.