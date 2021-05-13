namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Client
    {
        public int ClientID { get; set; }
        public string TitleCompany { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string AddressCompany { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Tag ClientStatus { get; set; }
        public string ContractPath { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}
