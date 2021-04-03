namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Position")]
    public partial class Position
    {
        public int ID_Position { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
