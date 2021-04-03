namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Provider_Product
    {
        public int ID_ProviderProduct { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
