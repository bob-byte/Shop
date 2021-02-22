namespace TestTaskWebitel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRelationshipBetweenTablesProductAndOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductOrder", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductOrder", "OrderId", "dbo.Order");
            DropIndex("dbo.ProductOrder", new[] { "ProductId" });
            DropIndex("dbo.ProductOrder", new[] { "OrderId" });
            DropTable("dbo.ProductOrder");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductOrder",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.OrderId });
            
            CreateIndex("dbo.ProductOrder", "OrderId");
            CreateIndex("dbo.ProductOrder", "ProductId");
            AddForeignKey("dbo.ProductOrder", "OrderId", "dbo.Order", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductOrder", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
    }
}
