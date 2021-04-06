namespace CRM.Model.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Request = new HashSet<Request>();
            Shipment = new HashSet<Shipment>();
        }

        [Key]
        public int ID_Client { get; set; }

        [Required]
        [StringLength(100)]
        public string TitleCompany { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        public long Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressCompany { get; set; }

        [StringLength(100)]
        public string ClientStatus { get; set; }

        [StringLength(200)]
        public string ContractPath { get; set; }

        [StringLength(100)]
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}
