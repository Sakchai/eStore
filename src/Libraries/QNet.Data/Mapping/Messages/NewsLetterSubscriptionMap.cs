using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Messages;

namespace QNet.Data.Mapping.Messages
{
    /// <summary>
    /// Represents a newsLetter subscription mapping configuration
    /// </summary>
    public partial class NewsLetterSubscriptionMap : QNetEntityTypeConfiguration<NewsLetterSubscription>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<NewsLetterSubscription> builder)
        {
            builder.ToTable(nameof(NewsLetterSubscription));
            builder.HasKey(subscription => subscription.Id);

            builder.Property(subscription => subscription.Email).HasMaxLength(255).IsRequired();
            builder.Property(subscription => subscription.Active).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}