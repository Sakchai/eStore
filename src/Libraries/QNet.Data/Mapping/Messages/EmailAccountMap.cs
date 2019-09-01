using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Messages;

namespace QNet.Data.Mapping.Messages
{
    /// <summary>
    /// Represents an email account mapping configuration
    /// </summary>
    public partial class EmailAccountMap : QNetEntityTypeConfiguration<EmailAccount>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<EmailAccount> builder)
        {
            builder.ToTable(nameof(EmailAccount));
            builder.HasKey(emailAccount => emailAccount.Id);

            builder.Property(emailAccount => emailAccount.Email).HasMaxLength(255).IsRequired();
            builder.Property(emailAccount => emailAccount.DisplayName).HasMaxLength(255);
            builder.Property(emailAccount => emailAccount.Host).HasMaxLength(255).IsRequired();
            builder.Property(emailAccount => emailAccount.Username).HasMaxLength(255).IsRequired();
            builder.Property(emailAccount => emailAccount.Password).HasMaxLength(255).IsRequired();

            builder.Ignore(emailAccount => emailAccount.FriendlyName);
            builder.Property(emailaccount => emailaccount.EnableSsl).HasColumnType("bit(1)");
            builder.Property(emailaccount => emailaccount.UseDefaultCredentials).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}