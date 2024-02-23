using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SystemSmallSoft.Models
{
    public class SmallSoftContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SmallSoftContext() : base("name=SmallSoftContext")
        {
        }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblDetalleVenta> TblDetalleVentas { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblProducto> TblProductoes { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblVenta> TblVentas { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblCliente> TblClientes { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblCategoria> TblCategorias { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblModoPago> TblModoPagoes { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.Estado> Estadoes { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.Municipio> Municipios { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.Localidad> Localidads { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblProveedor> TblProveedors { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblCompra> TblCompras { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblDetalleCompra> TblDetalleCompras { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblPurchase> TblPurchases { get; set; }

        public System.Data.Entity.DbSet<SystemSmallSoft.Models.TblProveedorProducto> TblProveedorProductoes { get; set; }
    }
}
