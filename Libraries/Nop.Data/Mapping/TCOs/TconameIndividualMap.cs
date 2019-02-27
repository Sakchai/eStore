using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.TCOs
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class TconameIndividualMap : NopEntityTypeConfiguration<TconameIndividual>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TconameIndividual> entity)
        {
            entity.ToTable(nameof(TconameCorporate));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CheckName).HasMaxLength(190);

            entity.Property(e => e.FirstName).HasMaxLength(60);

            entity.Property(e => e.FullName)
                .HasMaxLength(190)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.GuardianAddress)
                .HasMaxLength(255)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.GuardianBirthDate)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.GuardianContactNo)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.GuardianName)
                .HasMaxLength(255)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.LastName).HasMaxLength(70);

            entity.Property(e => e.MiddleName)
                .HasMaxLength(60)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.MotherMaiden)
                .HasMaxLength(120)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Occupation)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Tco)
                .IsRequired()
                .HasColumnName("TCO")
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.HasOne(d => d.TcOwner)
                .WithOne(p => p.TconameIndividual)
                .HasForeignKey<TconameIndividual>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TCONameIndividual_TCOwner");



            base.Configure(entity);
        }

        #endregion Methods
    }
}