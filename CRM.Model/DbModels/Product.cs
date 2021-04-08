namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public int Product_TypeID { get; set; }
        public virtual Product_Type Product_Type { get; set; }
        public virtual ICollection<Product_Of_Request> Product_Of_Requests { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
