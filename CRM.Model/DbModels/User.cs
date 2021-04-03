namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        public int ID_Users { get; set; }
        public int ID_Employee { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
