namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipment")]
    public partial class Shipment
    {
        [Key]
        public int ID_Shipment { get; set; }

        public int ID_Client { get; set; }

        public int ID_Employee { get; set; }

        public int ID_Request { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateShipment { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Request Request { get; set; }
    }
}
