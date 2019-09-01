using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Forums;

namespace QNet.Data.Mapping.Forums
{
    /// <summary>
    /// Represents a forum group mapping configuration
    /// </summary>
    public partial class ForumGroupMap : QNetEntityTypeConfiguration<ForumGroup>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ForumGroup> builder)
        {
            builder.ToTable(QNetMappingDefaults.ForumsGroupTable);
            builder.HasKey(forumGroup => forumGroup.Id);

            builder.Property(forumGroup => forumGroup.Name).HasMaxLength(200).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}