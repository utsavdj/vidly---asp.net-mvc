namespace Vidly.Migrations
{
  using System;
  using System.Data.Entity.Migrations;

  public partial class UpdateDOBofCustomer : DbMigration
  {
	public override void Up()
	{
	  Sql("UPDATE Customers SET DOB = '1980-01-01 WHERE id = 1'");
	}

	public override void Down()
	{
	}
  }
}
