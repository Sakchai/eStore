using System;
using System.Collections.Generic;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a shipment model
    /// </summary>
    public partial class ShipmentModel : BaseQNetEntityModel
    {
        #region Ctor

        public ShipmentModel()
        {
            ShipmentStatusEvents = new List<ShipmentStatusEventModel>();
            Items = new List<ShipmentItemModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Orders.Shipments.ID")]
        public override int Id { get; set; }

        public int OrderId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.TotalWeight")]
        public string TotalWeight { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.TrackingNumber")]
        public string TrackingNumber { get; set; }

        public string TrackingNumberUrl { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.ShippedDate")]
        public string ShippedDate { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.CanShip")]
        public bool CanShip { get; set; }

        public DateTime? ShippedDateUtc { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.DeliveryDate")]
        public string DeliveryDate { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.CanDeliver")]
        public bool CanDeliver { get; set; }

        public DateTime? DeliveryDateUtc { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Shipments.AdminComment")]
        public string AdminComment { get; set; }

        public List<ShipmentItemModel> Items { get; set; }

        public IList<ShipmentStatusEventModel> ShipmentStatusEvents { get; set; }

        #endregion
    }
}