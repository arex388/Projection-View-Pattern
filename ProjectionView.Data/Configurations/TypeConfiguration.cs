using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectionView.Data {
	internal sealed class TypeConfiguration :
		IEntityTypeConfiguration<Type> {
		public void Configure(
			EntityTypeBuilder<Type> builder) {
			builder.ToTable("Types").HasKey(
				k => k.Id);

			builder.Property(
				p => p.Name).HasMaxLength(255).IsRequired();
		}
	}
}