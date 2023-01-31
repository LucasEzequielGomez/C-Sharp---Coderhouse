/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Descripciones]
      ,[Costo]
      ,[PrecioVenta]
      ,[Stock]
      ,[IdUsuario]
  FROM [SistemaGestion].[dbo].[Producto]

  INSERT INTO Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)
  VALUES ('Nike', 34000, 35100, 100, 3)

  --Realizamos una consulta donde se ven los productos actuales (Nombre) y la persona que los cargo, con su Id (Nombre tambien)
  SELECT Producto.Descripciones, Usuario.Nombre
  FROM Producto
  INNER JOIN Usuario
  ON Producto.IdUsuario = Usuario.Id

  --Realizamos una venta de Productos por Usuario
  INSERT INTO Venta(IdUsuario, Comentarios)
  VALUES (3, 'Venta venta venta')

  INSERT INTO ProductoVendido(IdProducto, IdVenta, Stock)
  VALUES (5, 7, 1)
