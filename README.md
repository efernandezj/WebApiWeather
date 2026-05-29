# Weather Service API

Este proyecto implementa un servicio REST que consume datos de [Open-Meteo](https://open-meteo.com/en/docs), los almacena en MongoDB y expone endpoints para consultar información meteorológica.

## 🚀 Tecnologías utilizadas
- .NET 6 (ASP.NET Core Web API)
- MongoDB (base de datos local en contenedor)
- Swagger / OpenAPI (documentación automática)
- Docker & Docker Compose

---

## 📂 Estructura del proyecto
- WeatherApp.sln
- WeatherApp.Api/
- WeatherApp.Domain/
- WeatherApp.Infrastructure/
- WeatherApp.Application/
- docker-compose.yml

---

## ⚙️ Requisitos previos
- Tener instalado [Docker Desktop](https://www.docker.com/products/docker-desktop).
- Visual Studio 2022 o superior (opcional, solo si quieres compilar sin Docker).

---

## ▶️ Cómo ejecutar el proyecto

1. Clona el repositorio o descomprime el archivo `.zip` entregado.
2. Abre una terminal en la raíz del proyecto (donde está `docker-compose.yml`).
3. Ejecuta el siguiente comando:
   ```bash
   docker-compose up --build
   ```
4. Esto levantará:
- La API en http://localhost:5000/swagger
- MongoDB en mongodb://localhost:27017
