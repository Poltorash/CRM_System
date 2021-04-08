namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Employee
    {      
        public int EmployeeID { get; set; }
        public int PositionID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Shipment> Shipment { get; set; }
        public virtual ICollection<Supply> Supply { get; set; }
    }
}
