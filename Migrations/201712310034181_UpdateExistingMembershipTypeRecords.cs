namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateExistingMembershipTypeRecords : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET Name='PayAsYouGo' WHERE id = 1");
            Sql("UPDATE MEMBERSHIPTYPES SET Name='NeverGo' WHERE id = 2");
            Sql("UPDATE MEMBERSHIPTYPES SET Name='Zebra' WHERE id = 3");
        }
        
        public override void Down()
        {
         }
    }
}
