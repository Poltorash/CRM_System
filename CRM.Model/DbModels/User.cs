namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserStatus { get; set; }
    }
}
