using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.TCOs
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class TcoAddressMap : NopEntityTypeConfiguration<TcoAddress>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TcoAddress> entity)
        {
            entity.ToTable(nameof(TcoAddress));
            entity.HasKey(t => t.Id);
            entity.Property(e => e.Addr1).HasMaxLength(120);

            entity.Property(e => e.Addr2).HasMaxLength(120);

            entity.Property(e => e.AddrType)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.City).HasMaxLength(50);

            entity.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.Property(e => e.State).HasMaxLength(40);

            entity.Property(e => e.Tco)
                .IsRequired()
                .HasColumnName("TCO")
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.Property(e => e.TcownerId).HasColumnName("TCOwnerId");

            entity.Property(e => e.ZipCode).HasMaxLength(20);

            entity.HasOne(d => d.TcOwner)
                .WithMany(p => p.TcoAddress)
                .HasForeignKey(d => d.TcownerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TCOAddress_TCOwner");

            base.Configure(entity);
        }

        #endregion Methods
    }
}