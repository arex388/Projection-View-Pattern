using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectionView.Data {
	internal sealed class EmployeeConfiguration :
		IEntityTypeConfiguration<Employee> {
		public void Configure(
			EntityTypeBuilder<Employee> builder) {
			builder.ToTable("Employees").HasKey(
				k => k.Id);

			builder.Property(
				p => p.Name).HasMaxLength(255).IsRequired();
		}
	}
}