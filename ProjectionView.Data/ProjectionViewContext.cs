using Microsoft.EntityFrameworkCore;

namespace ProjectionView.Data {
	public class ProjectionViewContext :
		DbContext {
		public DbSet<Country> Countries { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public DbSet<Type> Types { get; set; }

		public ProjectionViewContext(
			string connectionString) :
			this(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options) {
		}

		public ProjectionViewContext(
			DbContextOptions options) :
			base(options) {
		}

		protected override void OnModelCreating(
			ModelBuilder modelBuilder) {
			modelBuilder.ApplyConfiguration(new CountryConfiguration());
			modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
			modelBuilder.ApplyConfiguration(new JobConfiguration());
			modelBuilder.ApplyConfiguration(new StateConfiguration());
			modelBuilder.ApplyConfiguration(new StatusConfiguration());
			modelBuilder.ApplyConfiguration(new TypeConfiguration());
		}
	}
}