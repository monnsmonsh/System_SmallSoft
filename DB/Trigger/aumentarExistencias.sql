use SmallSoft
go
CREATE TRIGGER AumentaExistencias
ON TblDetalleCompras
AFTER
INSERT
AS BEGIN
--Claramos dos variables
DECLARE @idProducto INT
DECLARE @cantidad INT
--Obtenemos el id del Producto y la cantidad que estamos comprando
SET @idProducto = (SELECT ProductoId FROM inserted);
SET @cantidad =(SELECT Stock FROM inserted);
--Disminuimos la existencia del producto en base a la cantidad que se compra
		UPDATE TblProductoes SET Stock = Stock + @cantidad
		WHERE TblProductoes.ProductoID = @idProducto;
END
GO