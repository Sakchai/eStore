﻿using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a measure search model
    /// </summary>
    public partial class MeasureSearchModel : BaseSearchModel
    {
        #region Ctor

        public MeasureSearchModel()
        {
            MeasureDimensionSearchModel = new MeasureDimensionSearchModel();
            MeasureWeightSearchModel = new MeasureWeightSearchModel();
        }

        #endregion

        #region Properties

        public MeasureDimensionSearchModel MeasureDimensionSearchModel { get; set; }

        public MeasureWeightSearchModel MeasureWeightSearchModel { get; set; }

        #endregion
    }
}