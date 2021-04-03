namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product_Of_Shipment
    {
        public int ID_Shipment { get; set; }
        public int ID_Product { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
