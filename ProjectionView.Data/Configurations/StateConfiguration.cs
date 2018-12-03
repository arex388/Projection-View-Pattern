using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectionView.Data {
	internal sealed class StateConfiguration :
		IEntityTypeConfiguration<State> {
		public void Configure(
			EntityTypeBuilder<State> builder) {
			builder.ToTable("States").HasKey(
				k => k.Id);

			builder.Property(
				p => p.Abbreviation).HasMaxLength(2).IsRequired();

			builder.Property(
				p => p.Name).HasMaxLength(255).IsRequired();

			builder.HasOne(
				t => t.Country).WithMany(
				t => t.States).HasForeignKey(
				k => k.CountryId);
		}
	}
}