using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a shipment search model
    /// </summary>
    public partial class ShipmentSearchModel : BaseSearchModel
    {
        #region Ctor

        public ShipmentSearchModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
            AvailableWarehouses = new List<SelectListItem>();
            ShipmentItemSearchModel = new ShipmentItemSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.TrackingNumber")]
        public string TrackingNumber { get; set; }
        
        public IList<SelectListItem> AvailableCountries { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.Country")]
        public int CountryId { get; set; }

        public IList<SelectListItem> AvailableStates { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.StateProvince")]
        public int StateProvinceId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.County")]
        public string County { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.City")]
        public string City { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.LoadNotShipped")]
        public bool LoadNotShipped { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.List.Warehouse")]
        public int WarehouseId { get; set; }

        public IList<SelectListItem> AvailableWarehouses { get; set; }

        public ShipmentItemSearchModel ShipmentItemSearchModel { get; set; }

        #endregion
    }
}