using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectionView.Data {
	internal sealed class CountryConfiguration :
		IEntityTypeConfiguration<Country> {
		public void Configure(
			EntityTypeBuilder<Country> builder) {
			builder.ToTable("Countries").HasKey(
				k => k.Id);

			builder.Property(
				p => p.Abbreviation).HasMaxLength(2).IsRequired();

			builder.Property(
				p => p.Name).HasMaxLength(255).IsRequired();
		}
	}
}