# MicroservicioAPI

# Microservicio API con CQRS y MediatR

Este proyecto es una API mínima desarrollada en **.NET 8** utilizando el patrón **CQRS** con **MediatR**, **Minimal APIs**, y almacenamiento en memoria con `ConcurrentDictionary`.

## 🚀 Características
- **CQRS con MediatR** para manejar comandos y consultas.
- **Persistencia en memoria** con `ConcurrentDictionary`.
- **Minimal API** con `WebApplication` en .NET 8.
- **Documentación con Swagger**.
- **Inyección de dependencias** para una arquitectura modular y escalable.

## 📂 Estructura del Proyecto
```
MicroservicioAPI
│   Program.cs
│
├───Entities
│       Product.cs
│
├───DTOs
│       CreateProductDto.cs
│
├───Repositories
│       IProductRepository.cs
│       InMemoryProductRepository.cs
│
├───Commands
│       CreateProductCommand.cs
│       CreateProductHandler.cs
│
├───Queries
│       GetAllProductsQuery.cs
│       GetAllProductsHandler.cs
│
├───Services
│       MediatRServiceRegistration.cs
```

## 🛠️ Configuración y Ejecución
### 1️⃣ Clonar el repositorio
```sh
 git clone https://github.com/oswaldobru01/MicroservicioAPI
 cd MicroservicioAPI
```
### 2️⃣ Restaurar paquetes
```sh
 dotnet restore
```
### 3️⃣ Ejecutar la aplicación
```sh
 dotnet run
```
Por defecto, la API estará disponible en `http://localhost:7038`

## 📖 Documentación con Swagger
Swagger UI está habilitado para interactuar con la API. Para acceder, abre en tu navegador:
```
http://localhost:7038/swagger
```

## 🔥 Endpoints Disponibles
### 📌 Crear un Producto
**Request:**
```sh
curl -X POST "http://localhost:7038/products" \
     -H "Content-Type: application/json" \
     -d '{ "name": "Laptop", "price": 1200.50 }'
```
**Response:**
```json
"id": "guid-del-producto"
```

### 📌 Obtener todos los Productos
**Request:**
```sh
curl -X GET "http://localhost:7038/products"
```
**Response:**
```json
[
  { "id": "guid-1", "name": "Laptop", "price": 1200.50 },
  { "id": "guid-2", "name": "Teclado", "price": 50.00 }
]
```

