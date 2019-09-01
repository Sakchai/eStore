
namespace QNet.Web.Framework.Models
{
    /// <summary>
    /// Represents base QNet entity model
    /// </summary>
    public partial class BaseQNetEntityModel : BaseQNetModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual int Id { get; set; }
    }
}