namespace SystemSmallSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        EstadoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.EstadoID);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        MunicipioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        EstadoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MunicipioID)
                .ForeignKey("dbo.Estadoes", t => t.EstadoID, cascadeDelete: true)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Localidads",
                c => new
                    {
                        LocalidadID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        MunicipioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocalidadID)
                .ForeignKey("dbo.Municipios", t => t.MunicipioID, cascadeDelete: true)
                .Index(t => t.MunicipioID);
            
            CreateTable(
                "dbo.TblCategorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.TblProductoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        SKU = c.String(nullable: false, maxLength: 15),
                        Descripcion = c.String(nullable: false, maxLength: 60),
                        CategoriaID = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                        PrecioCompra = c.Double(nullable: false),
                        Stock = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Cantidad = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.TblCategorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.TblDetalleVentas",
                c => new
                    {
                        DetalleVentaID = c.Int(nullable: false, identity: true),
                        VentaID = c.Int(nullable: false),
                        ProductoID = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        SubTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleVentaID)
                .ForeignKey("dbo.TblProductoes", t => t.ProductoID, cascadeDelete: true)
                .ForeignKey("dbo.TblVentas", t => t.VentaID, cascadeDelete: true)
                .Index(t => t.VentaID)
                .Index(t => t.ProductoID);
            
            CreateTable(
                "dbo.TblVentas",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        Folio = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        TblModoPago_ModoPagoID = c.Int(),
                    })
                .PrimaryKey(t => t.VentaID)
                .ForeignKey("dbo.TblClientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.TblModoPagoes", t => t.TblModoPago_ModoPagoID)
                .Index(t => t.ClienteID)
                .Index(t => t.TblModoPago_ModoPagoID);
            
            CreateTable(
                "dbo.TblClientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        ApPaterno = c.String(nullable: false),
                        ApMaterno = c.String(nullable: false),
                        RFC = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Correo = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        FechaAlta = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.TblModoPagoes",
                c => new
                    {
                        ModoPagoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModoPagoID);
            
            CreateTable(
                "dbo.TblProveedorProductoes",
                c => new
                    {
                        ProveedorProductoID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastBuy = c.DateTime(nullable: false),
                        ProveedorID = c.Int(nullable: false),
                        ProductoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorProductoID)
                .ForeignKey("dbo.TblProductoes", t => t.ProductoID, cascadeDelete: true)
                .ForeignKey("dbo.TblProveedors", t => t.ProveedorID, cascadeDelete: true)
                .Index(t => t.ProveedorID)
                .Index(t => t.ProductoID);
            
            CreateTable(
                "dbo.TblProveedors",
                c => new
                    {
                        ProveedorID = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(nullable: false),
                        RUC = c.String(nullable: false, maxLength: 13),
                        Marca = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Celular = c.String(nullable: false, maxLength: 10),
                        Representante = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        URL = c.String(),
                        FechaCompra = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProveedorID);
            
            CreateTable(
                "dbo.TblCompras",
                c => new
                    {
                        CompraID = c.Int(nullable: false, identity: true),
                        ProveedorID = c.Int(nullable: false),
                        Folio = c.String(),
                        FechaCompra = c.DateTime(nullable: false),
                        TblProductoes_ProductoID = c.Int(),
                    })
                .PrimaryKey(t => t.CompraID)
                .ForeignKey("dbo.TblProductoes", t => t.TblProductoes_ProductoID)
                .ForeignKey("dbo.TblProveedors", t => t.ProveedorID, cascadeDelete: true)
                .Index(t => t.ProveedorID)
                .Index(t => t.TblProductoes_ProductoID);
            
            CreateTable(
                "dbo.TblDetalleCompras",
                c => new
                    {
                        DetalleCompraID = c.Int(nullable: false, identity: true),
                        CompraID = c.Int(nullable: false),
                        ProductoID = c.Int(nullable: false),
                        PrecioCompra = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        SubTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleCompraID)
                .ForeignKey("dbo.TblCompras", t => t.CompraID, cascadeDelete: true)
                .ForeignKey("dbo.TblProductoes", t => t.ProductoID, cascadeDelete: true)
                .Index(t => t.CompraID)
                .Index(t => t.ProductoID);
            
            CreateTable(
                "dbo.TblPurchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        PurchaseProd = c.String(),
                        PurchaseCant = c.String(),
                        FechaCompra = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblDetalleCompras", "ProductoID", "dbo.TblProductoes");
            DropForeignKey("dbo.TblDetalleCompras", "CompraID", "dbo.TblCompras");
            DropForeignKey("dbo.TblCompras", "ProveedorID", "dbo.TblProveedors");
            DropForeignKey("dbo.TblCompras", "TblProductoes_ProductoID", "dbo.TblProductoes");
            DropForeignKey("dbo.TblProveedorProductoes", "ProveedorID", "dbo.TblProveedors");
            DropForeignKey("dbo.TblProveedorProductoes", "ProductoID", "dbo.TblProductoes");
            DropForeignKey("dbo.TblVentas", "TblModoPago_ModoPagoID", "dbo.TblModoPagoes");
            DropForeignKey("dbo.TblDetalleVentas", "VentaID", "dbo.TblVentas");
            DropForeignKey("dbo.TblVentas", "ClienteID", "dbo.TblClientes");
            DropForeignKey("dbo.TblDetalleVentas", "ProductoID", "dbo.TblProductoes");
            DropForeignKey("dbo.TblProductoes", "CategoriaID", "dbo.TblCategorias");
            DropForeignKey("dbo.Localidads", "MunicipioID", "dbo.Municipios");
            DropForeignKey("dbo.Municipios", "EstadoID", "dbo.Estadoes");
            DropIndex("dbo.TblDetalleCompras", new[] { "ProductoID" });
            DropIndex("dbo.TblDetalleCompras", new[] { "CompraID" });
            DropIndex("dbo.TblCompras", new[] { "TblProductoes_ProductoID" });
            DropIndex("dbo.TblCompras", new[] { "ProveedorID" });
            DropIndex("dbo.TblProveedorProductoes", new[] { "ProductoID" });
            DropIndex("dbo.TblProveedorProductoes", new[] { "ProveedorID" });
            DropIndex("dbo.TblVentas", new[] { "TblModoPago_ModoPagoID" });
            DropIndex("dbo.TblVentas", new[] { "ClienteID" });
            DropIndex("dbo.TblDetalleVentas", new[] { "ProductoID" });
            DropIndex("dbo.TblDetalleVentas", new[] { "VentaID" });
            DropIndex("dbo.TblProductoes", new[] { "CategoriaID" });
            DropIndex("dbo.Localidads", new[] { "MunicipioID" });
            DropIndex("dbo.Municipios", new[] { "EstadoID" });
            DropTable("dbo.TblPurchases");
            DropTable("dbo.TblDetalleCompras");
            DropTable("dbo.TblCompras");
            DropTable("dbo.TblProveedors");
            DropTable("dbo.TblProveedorProductoes");
            DropTable("dbo.TblModoPagoes");
            DropTable("dbo.TblClientes");
            DropTable("dbo.TblVentas");
            DropTable("dbo.TblDetalleVentas");
            DropTable("dbo.TblProductoes");
            DropTable("dbo.TblCategorias");
            DropTable("dbo.Localidads");
            DropTable("dbo.Municipios");
            DropTable("dbo.Estadoes");
        }
    }
}
