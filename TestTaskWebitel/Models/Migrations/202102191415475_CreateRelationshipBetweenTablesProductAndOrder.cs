namespace TestTaskWebitel.Models.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateRelationshipBetweenTablesProductAndOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductOrder",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.OrderId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductOrder", "OrderId", "dbo.Order");
            DropForeignKey("dbo.ProductOrder", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductOrder", new[] { "OrderId" });
            DropIndex("dbo.ProductOrder", new[] { "ProductId" });
            DropTable("dbo.ProductOrder");
        }
    }
}
