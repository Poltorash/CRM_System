namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product_Type
    {
        public int Product_TypeID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
