/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Comentarios]
      ,[IdUsuario]
  FROM [SistemaGestion].[dbo].[Venta]


--Select de todos los productos qu eno se vendieron y de los que nunca se vendieron

SELECT ProductoVendido.*, Producto.Descripciones FROM ProductoVendido
INNER JOIN Producto
ON Producto.Id = ProductoVendido.IdProducto

SELECT ProductoVendido.*, Producto.Descripciones FROM ProductoVendido
RIGHT OUTER JOIN Producto
ON Producto.Id = ProductoVendido.IdProducto

---En este caso, el producto de ID 4, 9 y 10


