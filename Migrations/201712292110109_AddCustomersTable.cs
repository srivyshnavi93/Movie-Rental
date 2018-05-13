namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO CUSTOMERS VALUES (1,'vyshnavi')");
            Sql("INSERT INTO CUSTOMERS VALUES (2,'chinnari')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
