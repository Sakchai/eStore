using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Forums;

namespace QNet.Data.Mapping.Forums
{
    /// <summary>
    /// Represents a forum post vote mapping configuration
    /// </summary>
    public partial class ForumPostVoteMap : QNetEntityTypeConfiguration<ForumPostVote>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ForumPostVote> builder)
        {
            builder.ToTable(QNetMappingDefaults.ForumsPostVoteTable);
            builder.HasKey(postVote => postVote.Id);

            builder.HasOne(postVote => postVote.ForumPost)
                .WithMany()
                .HasForeignKey(postVote => postVote.ForumPostId)
                .IsRequired();
            builder.Property(postVote => postVote.IsUp).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}