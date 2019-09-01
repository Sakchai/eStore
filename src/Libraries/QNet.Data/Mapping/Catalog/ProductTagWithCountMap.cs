using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product tag with count mapping configuration
    /// </summary>
    public partial class ProductTagWithCountMap : QNetQueryTypeConfiguration<ProductTagWithCount>
    {
    }
}