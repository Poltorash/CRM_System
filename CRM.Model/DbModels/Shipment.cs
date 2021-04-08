namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Shipment
    {
        public int ShipmentID { get; set; }
        public DateTime DateShipment { get; set; }
        public int ClientID { get; set; }
        public int EmployeeID { get; set; }
        public int? RequestID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Request Request { get; set; }
    }
}
