namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Provider
    {
        public int ProviderID { get; set; }
        public string TitleCompany { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<Supply> Supply { get; set; }
    }
}
