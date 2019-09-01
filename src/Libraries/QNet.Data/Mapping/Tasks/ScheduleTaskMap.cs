using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Tasks;

namespace QNet.Data.Mapping.Tasks
{
    /// <summary>
    /// Represents a schedule task mapping configuration
    /// </summary>
    public partial class ScheduleTaskMap : QNetEntityTypeConfiguration<ScheduleTask>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ScheduleTask> builder)
        {
            builder.ToTable(nameof(ScheduleTask));
            builder.HasKey(task => task.Id);

            builder.Property(task => task.Name).IsRequired();
            builder.Property(task => task.Type).IsRequired();
            builder.Property(scheduletask => scheduletask.Enabled).HasColumnType("bit(1)");
            builder.Property(scheduletask => scheduletask.StopOnError).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}