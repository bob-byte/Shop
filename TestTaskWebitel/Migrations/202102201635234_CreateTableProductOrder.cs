namespace TestTaskWebitel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateTableProductOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductOrders",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                    ProductId = c.Guid(nullable: false),
                    OrderId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.ProductOrders");
        }
    }
}