CREATE DATABASE TaskManager;
GO
USE TaskManager;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE, 
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE TaskStatus (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL UNIQUE -- Ej: 'Pendiente', 'En progreso', 'Completada'
);

CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(MAX),
    IdEstado INT NOT NULL,
    IdUsuario INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    

    CONSTRAINT FK_Tasks_Status FOREIGN KEY (IdEstado) REFERENCES TaskStatus(Id),
    CONSTRAINT FK_Tasks_Users FOREIGN KEY (IdUsuario) REFERENCES Users(Id) ON DELETE CASCADE
);
GO

-- =============================================
-- INSERCIÓN DE DATOS
-- =============================================

-- Insertar estados de tareas
INSERT INTO TaskStatus (Nombre) VALUES ('Pendiente'), ('En progreso'), ('Completada');

-- Insertar usuarios
INSERT INTO Users (Nombre, Email) VALUES 
('John Doe', 'johndoe@gmail.com'),
('Joaquin Vargas', 'joacovargas@gmail.com'),
('Juan Perez', 'juancito@gmail.com');

-- Insertar Tareas
INSERT INTO Tasks (Titulo, Descripcion, IdEstado, IdUsuario) VALUES 
('Limpiar en la cocina', 'Lavar platos y cubiertos', 3, 1), -- Completada
('Ordenar la habitacion', 'Guardar ropa y objetos', 2, 1); -- En progreso

INSERT INTO Tasks (Titulo, Descripcion, IdEstado, IdUsuario) VALUES 
('Hacer las compras', 'Comprar comida y bebidas', 3, 2), -- Completada
('reparar la cena', 'Cocinar la comida', 1, 2); -- Pendiente

INSERT INTO Tasks (Titulo, Descripcion, IdEstado, IdUsuario) VALUES 
('Limpiar el baño', 'Lavar el inodoro y el lavamanos', 1, 3), -- Pendiente
('Organizar el día', 'Anotar tareas pendientes', 1, 3); -- Pendiente