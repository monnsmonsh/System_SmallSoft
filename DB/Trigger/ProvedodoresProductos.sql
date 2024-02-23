use SmallSoft;

go
CREATE TRIGGER AumentaExistenciasProd
ON TblProveedorProductoes
AFTER
INSERT
AS BEGIN
--Claramos dos variables
DECLARE @idProducto int
DECLARE @cantidad INT
DECLARE @iva DECIMAL(18,2)
DECLARE @precio DECIMAL(18,2)
DECLARE @precioVenta DECIMAL(18,2)
DECLARE @precioCompra DECIMAL(18,2)
DECLARE @precioCompra2 DECIMAL(18,2)


--Obtenemos el id del Producto y la cantidad que estamos comprando
SET @idProducto = (SELECT ProductoId FROM inserted);
SET @cantidad =(SELECT cantidad FROM inserted);
SET @precioCompra2 = (SELECT Price FROM inserted);
SET @iva =(SELECT Price *.15 FROM inserted);
SET @precio = (SELECT Price + @iva FROM inserted);
SET @precioVenta = (SELECT PrecioUnitario from TblProductoes where ProductoID = @idProducto);
SET @precioCompra = (SELECT PrecioCompra from TblProductoes where ProductoID = @idProducto);
--aumentamos la existencia del producto en base a la cantidad que se compra
		IF @precio > @precioVenta
		BEGIN
			UPDATE TblProductoes SET Stock = Stock + @cantidad
			WHERE TblProductoes.ProductoID = @idProducto;

			UPDATE TblProductoes SET PrecioUnitario = PrecioUnitario + @precio
			WHERE TblProductoes.ProductoID = @idProducto;

			UPDATE TblProductoes SET PrecioCompra = PrecioCompra + @precioCompra2
			WHERE TblProductoes.ProductoID = @idProducto;
		END

		
		ELSE
		BEGIN
			UPDATE TblProductoes SET Stock = Stock + @cantidad
			WHERE TblProductoes.ProductoID = @idProducto;
		END
END
