namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class PopulateMovies : DbMigration
  {
	public override void Up()
	{
	  Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Hangover', 5, '2009-06-11', '2017-08-23', 5)");
	  Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Die Hard', 1, '1988-07-13', '2017-08-23', 3)");
	  Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('The Terminator', 1, '1984-10-26', '2017-08-23', 2)");
	  Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Toy Story', 3, '1995-11-19', '2017-08-23', 1)");
	  Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES ('Titanic', 4, '1997-12-18', '2017-08-23', 3)");
	}

	public override void Down()
	{
	}
  }
}
