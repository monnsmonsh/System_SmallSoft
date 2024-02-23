

USE [SmallSoft]
GO
--
INSERT INTO TblClientes(Nombre, ApPaterno,ApMaterno,RFC,Direccion,Telefono,Correo,Status,FechaAlta,Discriminator)values
	('Joaquin','Mendez', 'Gonzalez', 'XAXX010101000', 'Zona Centro 15', '4771239876','cliente@ejemplo.com',1,getdate(),'TblCliente'),
	('Rosa Mariel','Solis', 'Diaz', 'XAXX010101000', 'Zona Centro 15', '4771239876','cliente@ejemplo.com',1,getdate(),'TblCliente'),
	('Maria Susana','Garcia', 'Herrera', 'XAXX010101000', 'Zona Centro 15', '4771239876','cliente@ejemplo.com',1,getdate(),'TblCliente'),
	('Saul','Aranza', 'Cortez', 'XAXX010101000', 'Zona Centro 15', '4771239876','cliente@ejemplo.com',1,getdate(),'TblCliente')
go

INSERT INTO TblCategorias(Nombre,Status) values
	('DVR',1),
	('CAMARA',1)
go

INSERT INTO TblProductoes(SKU,Descripcion,PrecioCompra,PrecioUnitario,CategoriaId, Stock, Status,Discriminator) values 
	('KKmoon960H','KKmoon Equipo de Vídeo Digital de 8 Canales 960H D1 Red ',1920.05,2185.64,1,500,1,'TblProducto'),
	('DS-8124HQHI-K8','DVR 4 Megapixel - 24 Canales TURBOHD + 16 Canales IP ',2185.64,2885.99,1,200,1,'TblProducto'),
	('EV-8016-TURBO','DVR 8 Megapixel - 16 Canales 4K TURBOHD + 16 Canales IP',2795.64,3185.90,1,150,1,'TblProducto'),
	('DS-7208HUHI-K1','DVR 8 Megapixel - 8 Canales 4K TURBOHD + 8 Canales IP',4995.84,5685.90,1,300,1,'TblProducto'),
	('EV4008TURBO-X','DVR 4 Megapixel - 8 Canales TURBOHD + 4 Canales IP ',1999.84,2655.90,1,350,1,'TblProducto'),
	('DS-7216HUHI-K2','DVR 8 Megapixel - 16 Canales 4K TURBOHD + 16 Canales IP',2765.64,2985.90,1,150,1,'TblProducto'),
	('S16-TURBO-L','DVR 1080p Lite -- 16 Canales TURBOHD + 2 canales IP',1795.64,1999.90,1,120,1,'TblProducto'),
	('LB-7TURBO-G2','Bullet TURBOHD 720p - METALICA - Gran Angular 92',795.06,999.90,2,320,1,'TblProducto'),
	('DS-2AE4225T-IA','Domo PTZ TURBOHD 1080P - 25X Zoom - 100 mts IR',869.89,1299.99,2,30,1,'TblProducto')

go

INSERT INTO TblVentas(ClienteID,Folio,FechaAlta) values
	(1,'2019801',getdate())
go
INSERT INTO TblDetalleVentas(VentaID,ProductoID,PrecioUnitario,Cantidad,SubTotal) values
	(1,2,2185.64,1,2185.64)
go

