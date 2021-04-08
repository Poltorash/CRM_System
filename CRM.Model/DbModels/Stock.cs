namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Stock
    {
        public int StockID { get; set; }
        public int ID_Product { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
