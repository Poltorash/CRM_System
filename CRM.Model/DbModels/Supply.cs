namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Supply
    {
        public int SupplyID { get; set; }
        public DateTime DateSupply { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int EmployeeID { get; set; }
        public int Provider_ProductID { get; set; }
        public int ProviderID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Provider_Product Provider_Product { get; set; }
    }
}
