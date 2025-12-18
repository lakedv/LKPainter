# CatalogService.API

Microservicio de catálogo de modelos y partes para LKPainter.

Responsabilidades:
- Gestión de modelos base (miniaturas)
- Administración de partes SVG (cascos, armas, hombreras, etc.)
- Compatibilidad entre partes
- Definición de capas y orden de renderizado
- Soft delete y restauración de modelos
- Acceso restringido para acciones administrativas
- Validación de DTOs y manejo global de errores

Tecnologías:
ASP.NET Core · Entity Framework Core · SQL Server · FluentValidation

Este servicio provee la estructura lógica que consume el frontend (React + Konva).