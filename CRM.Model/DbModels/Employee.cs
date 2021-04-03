namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public partial class Employee
    {
        public int ID_Employee { get; set; }
        public int ID_Position { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public long Phone { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
