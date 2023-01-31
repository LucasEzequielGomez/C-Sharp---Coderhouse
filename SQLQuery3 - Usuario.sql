/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Nombre]
      ,[Apellido]
      ,[NombreUsuario]
      ,[Contraseña]
      ,[Mail]
  FROM [SistemaGestion].[dbo].[Usuario]

  

INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail)
VALUES ('Lucas', 'Gomez' , 'Luquitas07', 'Datos123!', 'lucasgomezmmo@gmail.com')
--Ejecute varias veces el INSERT INTO


DELETE FROM Usuario
WHERE Id = 7
--Borre los que se repetian, meh

INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail)
VALUES ('Mar', 'Araujo' , 'marcita', 'queondis', 'marmarmar@gmail.com')
--Inserto de nuevo, para probar, porque los ID no se vuelven a repetir.

