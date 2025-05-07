# API de Gestión de Productos y Categorías en ASP.NET Core 6
## Descripción
Esta API RESTful está construida con ASP.NET Core 6 para gestionar la información de productos y categorías. Ofrece un conjunto de funcionalidades básicas como CRUD (Crear, Leer, Actualizar, Eliminar), validaciones, mapeo automático con AutoMapper y documentación interactiva a través de Swagger. La arquitectura sigue una estructura en capas para facilitar el mantenimiento y escalabilidad.

## Tecnologías Utilizadas
- .NET 6 para la creación de la API

- Entity Framework Core para interacción con la base de datos

- SQL Server (en lugar de MySQL) usando enfoque Code First

- AutoMapper para simplificar la conversión de datos entre capas

- Swagger (Swashbuckle) para documentación y pruebas interactivas de la API

- DataAnnotations para validación de datos en los modelos


## Endpoints
## Categorías
- GET /api/categorias: Obtiene la lista de todas las categorías registradas.

- GET /api/categorias/{id}: Obtiene detalles de una categoría por su ID.

- POST /api/categorias: Crea una nueva categoría.

- DELETE /api/categorias/{id}: Elimina una categoría por su ID.

## Productos
- GET /api/productos: Obtiene todos los productos almacenados.

- GET /api/productos/{id}: Obtiene los detalles de un producto específico.

- POST /api/productos: Registra un nuevo producto en la base de datos.

- PUT /api/productos/{id}: Actualiza la información de un producto existente.

- DELETE /api/productos/{id}: Elimina un producto especificado por su ID.


