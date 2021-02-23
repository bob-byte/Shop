namespace TestTaskWebitel.Models.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateExplicitRelationshipBetweenTablesProductAndOrder : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ProductOrders", "ProductId");
            CreateIndex("dbo.ProductOrders", "OrderId");
            AddForeignKey("dbo.ProductOrders", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductOrders", "OrderId", "dbo.Order", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrders", "OrderId", "dbo.Order");
            DropForeignKey("dbo.ProductOrders", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductOrders", new[] { "OrderId" });
            DropIndex("dbo.ProductOrders", new[] { "ProductId" });
        }
    }
}
