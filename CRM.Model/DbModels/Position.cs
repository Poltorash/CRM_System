namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Position
    {

        public int PositionID { get; set; }
        public string Title { get; set; }
        public double Salary { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
