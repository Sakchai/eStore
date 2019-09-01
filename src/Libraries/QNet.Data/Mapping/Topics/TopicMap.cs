using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Topics;

namespace QNet.Data.Mapping.Topics
{
    /// <summary>
    /// Represents a topic mapping configuration
    /// </summary>
    public partial class TopicMap : QNetEntityTypeConfiguration<Topic>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable(nameof(Topic));
            builder.HasKey(topic => topic.Id);
            builder.Property(topic => topic.AccessibleWhenStoreClosed).HasColumnType("bit(1)");
            builder.Property(topic => topic.IncludeInFooterColumn1).HasColumnType("bit(1)");
            builder.Property(topic => topic.IncludeInFooterColumn2).HasColumnType("bit(1)");
            builder.Property(topic => topic.IncludeInFooterColumn3).HasColumnType("bit(1)");
            builder.Property(topic => topic.IncludeInSitemap).HasColumnType("bit(1)");
            builder.Property(topic => topic.IncludeInTopMenu).HasColumnType("bit(1)");
            builder.Property(topic => topic.IsPasswordProtected).HasColumnType("bit(1)");
            builder.Property(topic => topic.LimitedToStores).HasColumnType("bit(1)");
            builder.Property(topic => topic.Published).HasColumnType("bit(1)");
            builder.Property(topic => topic.SubjectToAcl).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}