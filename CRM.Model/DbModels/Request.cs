namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Request")]
    public partial class Request
    {
        public int ID_Request { get; set; }
        public int ID_Client { get; set; }
        public DateTime DateRequest { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Product_Of_Request> Product_Of_Request { get; set; }
    }
}
