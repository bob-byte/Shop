namespace TestTaskWebitel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnIdOfTheTableProductOrder : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductOrders");
            AlterColumn("dbo.ProductOrders", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AddPrimaryKey("dbo.ProductOrders", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProductOrders");
            AlterColumn("dbo.ProductOrders", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ProductOrders", "Id");
        }
    }
}
