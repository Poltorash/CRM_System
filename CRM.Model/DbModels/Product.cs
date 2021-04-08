namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {        
        public int ProductID { get; set; }
        public int ID_ProductType { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public virtual Product_Type Product_Type { get; set; }
        public virtual ICollection<Request> Product_Of_Request { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
