using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.TCOs
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class TcoAttributeMap : NopEntityTypeConfiguration<TcoAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TcoAttribute> builder)
        {
            builder.ToTable(nameof(TcoAttribute));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CreatedBy)
                 .HasMaxLength(20)
                 .IsUnicode(false);

            builder.Property(t => t.Irvalue)
                .HasColumnName("IRValue")
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(t => t.NumericValue).HasColumnType("decimal(18, 2)");

            builder.Property(t => t.Remarks).HasMaxLength(50);

            builder.Property(t => t.Tco)
                .IsRequired()
                .HasColumnName("TCO")
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(t => t.TcownerId).HasColumnName("TCOwnerId");

            builder.Property(t => t.TextValue).HasMaxLength(200);

            builder.HasOne(t => t.Tcowner)
                .WithMany(p => p.TcoAttribute)
                .HasForeignKey(t => t.TcownerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TCOAttributes_TCOwner");

            base.Configure(builder);
        }

        #endregion Methods
    }
}