using CRM.Model.DbModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CRM.Context
{
    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Type> Product_Type { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Provider_Product> Provider_Product { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product_Of_Request> Product_Of_Request { get; set; }
        public virtual DbSet<Product_Of_Shipment> Product_Of_Shipment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.TitleCompany)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.LastName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.FirstName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Patronymic)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.AddressCompany)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Tag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ContractPath)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Shipments)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Patronymic)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Shipments)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Title)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Title)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Of_Request)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Of_Shipment)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Stocks)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product_Type>()
                .Property(e => e.Title)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product_Type>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Product_Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.TitleCompany)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.LastName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.FirstName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.Patronymic)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.ContractPath)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.Provider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider_Product>()
                .Property(e => e.Title)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Provider_Product>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.Provider_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.Product_Of_Request)
                .WithRequired(e => e.Request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipment>()
                .HasMany(e => e.Product_Of_Shipment)
                .WithRequired(e => e.Shipment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserLogin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPassword)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
