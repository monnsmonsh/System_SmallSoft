namespace SystemSmallSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemInitial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblProductoes", "IMG", c => c.Binary());
            AddColumn("dbo.TblProveedorProductoes", "cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblProveedorProductoes", "cantidad");
            DropColumn("dbo.TblProductoes", "IMG");
        }
    }
}
