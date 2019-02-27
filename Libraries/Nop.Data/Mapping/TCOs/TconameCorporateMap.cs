using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.TCOs
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class TconameCorporateMap : NopEntityTypeConfiguration<TconameCorporate>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TconameCorporate> entity)
        {
            entity.ToTable(nameof(TconameCorporate));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BusinessType)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.CheckName).HasMaxLength(190);

            entity.Property(e => e.CompanyName).HasMaxLength(190);

            entity.Property(e => e.ContactPerson)
                .HasMaxLength(255)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.ContactPosition)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.ContactPositionOther)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Tco)
                .IsRequired()
                .HasColumnName("TCO")
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.Property(e => e.TitleContactPerson)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.HasOne(d => d.TcOwner)
                .WithOne(p => p.TconameCorporate)
                .HasForeignKey<TconameCorporate>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TCONameCorporate_TCOwner");



            base.Configure(entity);
        }

        #endregion Methods
    }
}