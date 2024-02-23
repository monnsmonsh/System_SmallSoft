namespace SystemSmallSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemInitial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblDetalleVentas", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.TblVentas", "SubTotal", c => c.Double(nullable: false));
            AddColumn("dbo.TblVentas", "iva", c => c.Double(nullable: false));
            AddColumn("dbo.TblVentas", "Total", c => c.Double(nullable: false));
            DropColumn("dbo.TblDetalleVentas", "SubTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblDetalleVentas", "SubTotal", c => c.Double(nullable: false));
            DropColumn("dbo.TblVentas", "Total");
            DropColumn("dbo.TblVentas", "iva");
            DropColumn("dbo.TblVentas", "SubTotal");
            DropColumn("dbo.TblDetalleVentas", "Total");
        }
    }
}
