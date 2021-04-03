namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Client")]
    public partial class Client
    {
        public int ID_Client { get; set; }
        public string TitleCompany { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public long Phone { get; set; }
        public string AddressCompany { get; set; }
        public string Tag { get; set; }
        public string ContractPath { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
