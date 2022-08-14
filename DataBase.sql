USE master
GO

DROP DATABASE IF EXISTS ListadoMusica
GO

CREATE DATABASE ListadoMusica
GO

USE ListadoMusica
GO

--------------------------------------------

CREATE TABLE Cancion (
idCancion INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
titulo VARCHAR (200) NOT NULL,
artista VARCHAR (200) NOT NULL,
año CHAR (4) NOT NULL,
genero VARCHAR(200) NOT NULL,
estatus INT DEFAULT 1 NOT NULL,
idUsuarioAgrega INT NOT NULL,
fechaAgrega DATETIME DEFAULT GETDATE()
);

CREATE TABLE Usuario (
idUsuario INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
nombreUsuario VARCHAR (200) NOT NULL,
estatus INT DEFAULT 1 NOT NULL
);

-------------------------------------------

ALTER TABLE Cancion
ADD CONSTRAINT FKCancionUsuarioAgrega
FOREIGN KEY (idUsuarioAgrega)
REFERENCES Usuario (idUsuario)

--------------------------------------------

CREATE INDEX ixCancion ON Cancion (idCancion)
GO

-------------------------------------------


INSERT INTO Usuario (nombreUsuario) VALUES ('Gilberto'), ('Glenda')

INSERT INTO Cancion (titulo, artista, año, genero, idUsuarioAgrega,idUsuarioModifica) VALUES ('Adiós Amor', 'Christian Nodal','2014', 'Regional Mexicano', 1,1), ('La Bachata', 'Manuel Turizo','2022', 'Bachata', 2,1), 
('Mi Corrido', 'Julión Álvarez','2015', 'Regional Mexicano', 2,1)
GO
-------------------------------------------

CREATE VIEW vwCancionesFavoritas
AS SELECT
Cancion.idCancion as '#',
Cancion.titulo as 'Titulo de canción',
Cancion.artista as Artista,
Cancion.año as 'Año',
Cancion.genero as 'Género',
U1.nombreUsuario as 'Agregada por:',
Cancion.fechaAgrega as 'Agregada en:'

FROM Cancion 
INNER JOIN Usuario as U1 ON U1.idUsuario = Cancion.idUsuarioAgrega WHERE Cancion.estatus = 1; 
             
GO

SELECT * FROM vwCancionesFavoritas 
