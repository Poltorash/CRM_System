namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Request
    {       
        public int RequestID { get; set; }
        public int ID_Client { get; set; }      
        public DateTime DateRequest { get; set; }
        public string StatusRequest { get; set; }
        public List<int> Quantity { get; set; }
        public  List<double> Price { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}
