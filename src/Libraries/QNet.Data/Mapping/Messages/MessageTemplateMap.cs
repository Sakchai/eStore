using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Messages;

namespace QNet.Data.Mapping.Messages
{
    /// <summary>
    /// Represents a message template mapping configuration
    /// </summary>
    public partial class MessageTemplateMap : QNetEntityTypeConfiguration<MessageTemplate>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<MessageTemplate> builder)
        {
            builder.ToTable(nameof(MessageTemplate));
            builder.HasKey(template => template.Id);

            builder.Property(template => template.Name).HasMaxLength(200).IsRequired();
            builder.Property(template => template.BccEmailAddresses).HasMaxLength(200);
            builder.Property(template => template.Subject).HasMaxLength(1000);
            builder.Property(template => template.EmailAccountId).IsRequired();

            builder.Ignore(template => template.DelayPeriod);
            builder.Property(messagetemplate => messagetemplate.IsActive).HasColumnType("bit(1)");
            builder.Property(messagetemplate => messagetemplate.LimitedToStores).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}