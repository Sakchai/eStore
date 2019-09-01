using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Polls;

namespace QNet.Data.Mapping.Polls
{
    /// <summary>
    /// Represents a poll mapping configuration
    /// </summary>
    public partial class PollMap : QNetEntityTypeConfiguration<Poll>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable(nameof(Poll));
            builder.HasKey(poll => poll.Id);

            builder.Property(poll => poll.Name).IsRequired();

            builder.HasOne(poll => poll.Language)
                .WithMany()
                .HasForeignKey(poll => poll.LanguageId)
                .IsRequired();
            builder.Property(poll => poll.AllowGuestsToVote).HasColumnType("bit(1)");
            builder.Property(poll => poll.LimitedToStores).HasColumnType("bit(1)");
            builder.Property(poll => poll.Published).HasColumnType("bit(1)");
            builder.Property(poll => poll.ShowOnHomepage).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}