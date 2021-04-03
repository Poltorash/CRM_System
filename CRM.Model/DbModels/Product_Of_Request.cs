namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product_Of_Request
    {
        public int ID_Request { get; set; }
        public int ID_Product { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Request Request { get; set; }
    }
}
