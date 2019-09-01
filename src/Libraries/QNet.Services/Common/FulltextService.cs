using System.Linq;
using QNet.Core.Domain.Common;
using QNet.Data;

namespace QNet.Services.Common
{
    /// <summary>
    /// Full-Text service
    /// </summary>
    public partial class FulltextService : IFulltextService
    {
        #region Fields

        private readonly IDbContext _dbContext;

        #endregion

        #region Ctor

        public FulltextService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets value indicating whether Full-Text is supported
        /// </summary>
        /// <returns>Result</returns>
        public virtual bool IsFullTextSupported()
        {
            var result = _dbContext
                .QueryFromSql<IntQueryType>("EXEC [FullText_IsSupported]")
                .Select(intValue => intValue.Value).FirstOrDefault();
            return result > 0;
        }

        /// <summary>
        /// Enable Full-Text support
        /// </summary>
        public virtual void EnableFullText()
        {
            _dbContext.ExecuteSqlCommand("EXEC [FullText_Enable]", true);
        }

        /// <summary>
        /// Disable Full-Text support
        /// </summary>
        public virtual void DisableFullText()
        {
            _dbContext.ExecuteSqlCommand("EXEC [FullText_Disable]", true);
        }

        #endregion
    }
}