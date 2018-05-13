namespace Vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class PopulateMoviesToTables : DbMigration
	{
		public override void Up()
		{
			Sql("INSERT INTO MOVIES (Name,GenreId,DateAdded,ReleaseDate,NumberInstock,NumberAvailable) VALUES ('SHREK!',1,'2000-02-03 00:00:00','2011-02-03 00:00:00',5,10)");
			Sql("INSERT INTO MOVIES (Name,GenreId,DateAdded,ReleaseDate,NumberInstock,NumberAvailable) VALUES ('ADVENTURE!',2,'2011-02-03 00:00:00','2011-02-03 00:00:00',7,9)");
			Sql("INSERT INTO MOVIES (Name,GenreId,DateAdded,ReleaseDate,NumberInstock,NumberAvailable) VALUES ('FROZEN!',3,'2012-02-03 00:00:00','2011-02-03 00:00:00',6,8)");
			

		}
		
		public override void Down()
		{
		}
	}
}
