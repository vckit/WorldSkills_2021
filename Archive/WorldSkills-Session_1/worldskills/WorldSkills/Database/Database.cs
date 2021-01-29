namespace WorldSkills.Database
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Database : DbContext
	{
		public Database()
			: base("name=Database")
		{
		}

		public virtual DbSet<Driver> Driver { get; set; }
		public virtual DbSet<RegionCodes> RegionCodes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
