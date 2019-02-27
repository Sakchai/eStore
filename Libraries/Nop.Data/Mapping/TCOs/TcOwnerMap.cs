using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.TCOs
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class TcOwnerMap : NopEntityTypeConfiguration<TcOwner>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TcOwner> builder)
        {
            builder.ToTable(nameof(TcOwner));
            builder.HasKey(tcowner => tcowner.Id);

            builder.Property(tcowner => tcowner.ActDlno).HasColumnName("ActDLNo");

            builder.Property(tcowner => tcowner.AuditBy)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.BirthDate).HasColumnType("datetime");

            builder.Property(tcowner => tcowner.ChangedBy)
                .HasMaxLength(60)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.CivilStat)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.DateActivated).HasColumnType("smalldatetime");

            builder.Property(tcowner => tcowner.DateApplied).HasColumnType("datetime");

            builder.Property(tcowner => tcowner.DateChanged).HasColumnType("datetime");

            builder.Property(tcowner => tcowner.DateDeleted).HasColumnType("datetime");

            builder.Property(tcowner => tcowner.Email)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.Email2)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.FirstFridayAfterRegExpire).HasColumnType("datetime");

            builder.Property(tcowner => tcowner.Fname)
                .HasColumnName("FName")
                .HasMaxLength(90)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.Gender)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.InnerLock).HasDefaultValueSql("((1))");

            builder.Property(tcowner => tcowner.IsF2allowed)
                .HasColumnName("IsF2Allowed")
                .HasDefaultValueSql("((1))");

            builder.Property(tcowner => tcowner.IsQ2allowed).HasColumnName("IsQ2Allowed");

            builder.Property(tcowner => tcowner.MaxExtension).HasDefaultValueSql("((20))");

            builder.Property(tcowner => tcowner.Mlname)
                .HasColumnName("MLName")
                .HasMaxLength(120)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.NatCode)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.Nature)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.NextRegRenewalDate).HasColumnType("datetime");

            builder.Property(tcowner => tcowner.OnAcctAmount).HasColumnType("decimal(18, 0)");

            builder.Property(tcowner => tcowner.Q2rank).HasColumnName("Q2Rank");

            builder.Property(tcowner => tcowner.QplusAdvancementRank).HasColumnName("QPlusAdvancementRank");

            builder.Property(tcowner => tcowner.QplusPaidAsRank).HasColumnName("QPlusPaidAsRank");

            builder.Property(tcowner => tcowner.Referrer)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.ShipContactName)
                .HasMaxLength(190)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.ShipEmailAddr)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.SpouseBirthdate).HasColumnType("datetime");

            builder.Property(tcowner => tcowner.SpouseName)
                .HasMaxLength(190)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.Tco)
                .IsRequired()
                .HasColumnName("TCO")
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(tcowner => tcowner.Tcoalias)
                .HasColumnName("TCOAlias")
                .HasMaxLength(20);

            builder.Property(tcowner => tcowner.Tcoclass).HasColumnName("TCOClass");

            builder.Property(tcowner => tcowner.Tcostatus)
                .HasColumnName("TCOStatus")
                .HasDefaultValueSql("((1))");

            builder.Property(tcowner => tcowner.UniReferrer)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.ValidId)
                .HasColumnName("ValidID")
                .HasMaxLength(30)
                .HasDefaultValueSql("('')");

            builder.Property(tcowner => tcowner.ValidIdType)
                .IsRequired()
                .HasColumnName("ValidID_Type")
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            builder.Property(tcowner => tcowner.CustomerId).HasColumnName("CustomerId");
            builder.HasOne(tcowner => tcowner.Customer)
                .WithMany()
                .HasForeignKey(tcowner => tcowner.CustomerId);

            builder.Ignore(tcowner => tcowner.OrderHeader);
            builder.Ignore(tcowner => tcowner.PaymentHeader);
            builder.Ignore(tcowner => tcowner.TconameCorporate);
            builder.Ignore(tcowner => tcowner.TconameIndividual);

            base.Configure(builder);
        }

        #endregion Methods
    }
}