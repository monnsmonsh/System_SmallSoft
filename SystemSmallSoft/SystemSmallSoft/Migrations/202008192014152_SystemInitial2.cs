namespace SystemSmallSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemInitial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblDetalleCompras", "Stock", c => c.Int(nullable: false));
            DropColumn("dbo.TblDetalleCompras", "Cantidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblDetalleCompras", "Cantidad", c => c.Int(nullable: false));
            DropColumn("dbo.TblDetalleCompras", "Stock");
        }
    }
}
