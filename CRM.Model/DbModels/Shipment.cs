namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Shipment")]
    public partial class Shipment
    {
        public int ID_Shipment { get; set; }
        public int ID_Client { get; set; }
        public int ID_Employee { get; set; }
        public DateTime DateShipment { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Product_Of_Shipment> Product_Of_Shipment { get; set; }
    }
}
