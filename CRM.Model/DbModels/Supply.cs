namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Supply")]
    public partial class Supply
    {
        public int ID_Supply { get; set; }
        public int ID_Employee { get; set; }
        public int ID_ProviderProduct { get; set; }
        public int ID_Provider { get; set; }
        public DateTime DateSupply { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Provider_Product Provider_Product { get; set; }
    }
}
