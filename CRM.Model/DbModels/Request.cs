namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Request
    {       
        public int RequestID { get; set; }
        public int ClientID { get; set; }      
        public DateTime DateRequest { get; set; }
        public StatusRequest StatusRequest { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Product_Of_Request> Product_Of_Requests { get; set; }
        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}
