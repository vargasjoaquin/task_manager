Gestor de tareas Fullstack - Prueba Tecnica

Este proyecto es una solución integral para un Gestor de Tareas diario, diseñada bajo una arquitectura desacoplada y robusta, cumpliendo con los requerimientos técnicos para el puesto de Desarrollador Junior Fullstack.

----

1. **Descripcion del proyecto**

   El sistema permite realizar el ciclo completo de gestión de datos (CRUD), filtrado dinámico y aplicación de reglas de negocio en capas independientes. Se diseñó para ser escalable, fácil de mantener y eficiente en la comunicación entre el cliente (React) y el servidor (.NET).

----

2. **Arquitectura de software**
   
   Se ha implementado el patron de **Clean Arquitecture (Arquitectura limpia)** para garantizar la logica de negocio sea independiente de los frameworks como de los detalles tecnicos.
   

   **Organizacion de capas (Backend):**
   
   **Entities:** Definición de objetos de dominio (Task, User, Status).
   
   **Interfaces:** Contratos que definen el comportamiento de los repositorios y servicios (Inversión de Dependencias - SOLID).
   
   **DTOs:** Objetos planos de transferencia de datos para la comunicación externa, garantizando seguridad al no exponer las entidades de la DB.
   
   **Services:** Capa de lógica de negocio que coordina el flujo de datos.
   
   **Data:** Implementación del DbContext de Entity Framework Core para la gestión de SQL Server.
   
   **Repositories:** Implementación del patrón Repository para centralizar la lógica de acceso a datos.
   
   **Controllers:** Gestiona el ruteo HTTP, el binding de parámetros y la devolución de códigos de respuesta estandarizados.

   ----
   

3. **Esquema de base de datos**

   El diseño de la misma corresponde a la **Tercera Forma Normal (3NF)** para evitar redundancias y asegurar integridad referencial.

   **Users:** Registro de usuarios del sistema.
   
   **TaskStatus:** Tabla maestra para la tipificación de estados permitidos (Pendiente, En progreso, Completada).
   
   **Tasks:** Tabla principal con Claves Foráneas (FK) vinculadas a Usuarios y Estados.

   ----

4. **Stack de tecnologias**
   
   **Backend:** .NET 8.0 Web API (C#).
   
   **Frontend:** React 18+ (Vite) con Hooks funcionales.
   
   **ORM:** Entity Framework Core 8.0.
   
   **Database:** Microsoft SQL Server.
   
   **Documentación:** Swagger (OpenAPI 3.0).

  ----

  5. **Decisiones tecnicas relevantes**

   **Asincronía:** Todos los procesos son async/await, optimizando el manejo de hilos del servidor.

   **CORS Policy:** Implementación de política de intercambio entre orígenes para permitir comunicación segura con el dominio local de React.

   **Ruteo y Binding:** Uso de rutas absolutas [Route("api/tasks")] y corrección de naming en parámetros para asegurar la compatibilidad total entre JSON y C#.

   **Separación de Responsabilidades:** El controlador delega al servicio, y el servicio al repositorio, aislando cada parte del proceso (Se recomienda revisar el controlador TaskController.cs). 

   ----

   6. **Instrucciones para ejecucion local**

   **Paso 1: Base de Datos**
   
  1. Diríjase a la carpeta /database.
  2. Ejecute el script init.sql para crear la estructura e insertar datos semilla.
     
   **Paso 2: Backend (API)**
   
  1. Configure la ConnectionString en el archivo appsettings.json.
  2. Abra el proyecto en Visual Studio y ejecútelo.
  3. Puede acceder a la UI de Swagger en: https://localhost:7273/swagger/index.html

   **Paso 3: Frontend (React)**
   
  1. Navegue a la carpeta /frontend.
  2. Ejecute los comandos:
     
          npm install
          npm run dev

  ----

  7. **Documentacion de la API**
      
      Se adjunta la especificación OpenAPI 3.0 en formato YAML:

      Ubicacion: api-documentation/api-specification.yaml

      Para visulizarlo de manera mas interativa, pegue el contenido en Swagger Editor Online (https://editor.swagger.io/)

  ----

  8. **Uso de la IA**

     Se declara el uso de herramientas de IA (ChatGPT/Google IA Studio) como apoyo durante el desarrollo para:

     - Definición inicial de la arquitectura por capas y estructuración de la documentación bajo estándares industriales.
     
     - Soporte en la depuración de errores de vinculación (Route Binding) y mapeo de tipos de datos.
     
     - Generación de plantillas base para los componentes visuales de React, ademas de problemas al instalar los paquetes.
    
   ----
    
Autor: Vargas Joaquin Leon.

22 de Abril del 2026.
   
