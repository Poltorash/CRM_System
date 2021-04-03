namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product_Type
    {
        public int ID_ProductType { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
