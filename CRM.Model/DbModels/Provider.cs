namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Provider")]
    public partial class Provider
    {
        public int ID_Provider { get; set; }
        public string TitleCompany { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public long Phone { get; set; }
        public string ContractPath { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
