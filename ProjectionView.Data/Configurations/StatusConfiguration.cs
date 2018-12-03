using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectionView.Data {
	internal sealed class StatusConfiguration :
		IEntityTypeConfiguration<Status> {
		public void Configure(
			EntityTypeBuilder<Status> builder) {
			builder.ToTable("Statuses").HasKey(
				k => k.Id);

			builder.Property(
				p => p.Name).HasMaxLength(255).IsRequired();
		}
	}
}
