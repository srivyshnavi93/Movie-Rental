namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES VALUES(1,'COMEDY')");
            Sql("INSERT INTO GENRES VALUES(2,'HORROR')");
            Sql("INSERT INTO GENRES VALUES(3,'DOCUMENTARY')");
            Sql("INSERT INTO GENRES VALUES(4,'INSPIRATIONAL')");
        }
        
        public override void Down()
        {
        }
    }
}
