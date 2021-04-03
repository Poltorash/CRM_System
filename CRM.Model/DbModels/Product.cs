namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public partial class Product
    {
        public int ID_Product { get; set; }
        public int ID_ProductType { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public virtual Product_Type Product_Type { get; set; }
        public virtual ICollection<Product_Of_Request> Product_Of_Request { get; set; }
        public virtual ICollection<Product_Of_Shipment> Product_Of_Shipment { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
