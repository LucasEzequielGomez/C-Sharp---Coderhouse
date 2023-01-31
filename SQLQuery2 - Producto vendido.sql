/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Stock]
      ,[IdProducto]
      ,[IdVenta]
  FROM [SistemaGestion].[dbo].[ProductoVendido]

