using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectionView.Data {
	internal sealed class JobConfiguration :
		IEntityTypeConfiguration<Job> {
		public void Configure(
			EntityTypeBuilder<Job> builder) {
			builder.ToTable("Jobs").HasKey(
				k => k.Id);

			builder.Property(
				p => p.Name).HasMaxLength(255).IsRequired();

			builder.HasOne(
				t => t.Csr).WithMany(
				t => t.Jobs).HasForeignKey(
				k => k.CsrId);

			builder.HasOne(
				t => t.State).WithMany(
				t => t.Jobs).HasForeignKey(
				k => k.StateId);

			builder.HasOne(
				t => t.Status).WithMany(
				t => t.Jobs).HasForeignKey(
				k => k.StatusId);

			builder.HasOne(
				t => t.Type).WithMany(
				t => t.Jobs).HasForeignKey(
				k => k.TypeId);
		}
	}
}