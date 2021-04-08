namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Shipment
    {
        public int ShipmentID { get; set; }
        public int ID_Client { get; set; }
        public int ID_Employee { get; set; }
        public int ID_Request { get; set; }
        public DateTime DateShipment { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Request Request { get; set; }
    }
}
