namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product_Of_Request
    {
        public int Product_Of_RequestID { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
        public int ProductID { get; set; }
        public int RequestID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Request Request { get; set; }
    }
}
