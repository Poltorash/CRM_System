namespace CRM.Context
{
    using CRM.Model.DbModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CRM_Model : DbContext
    {
        // Контекст настроен для использования строки подключения "CRM_Model" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "CRM.Context.CRM_Model" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "CRM_Model" 
        // в файле конфигурации приложения.
        public CRM_Model()
            : base("name=CRM_Model")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Type> Product_Types { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Provider_Product> Provider_Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Supply> Supplys { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product_Of_Request> Product_Of_Request { get; set; }

        public string AddClient(string title, string lastName, string firstName, string patronymic, string phone, string addressCompany, string clientStatus, string contractPath, string photo) 
        {
            try
            {
                Clients.Add(new Client()
                {
                    TitleCompany = title,
                    LastName = lastName,
                    FirstName = firstName,
                    Patronymic = patronymic,
                    Phone = phone,
                    AddressCompany = addressCompany,
                    ClientStatus = clientStatus,
                    ContractPath = contractPath,
                    Photo = photo
                });
                SaveChanges();
                return "Запись добавлена!";
            }
            catch(Exception ex) { return ex.Message; }
        }
        public string AddEmployee(string lastName, string firstName, string patronymic, string phone, int ID_position)
        {
            try
            {
                Employee employee = new Employee()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    Patronymic = patronymic,
                    Phone = phone,
                    PositionID = ID_position
                };
                Employees.Add(employee);
                Positions.FirstOrDefault(i=>i.PositionID == ID_position).Employee.Add(employee);
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddPosition(string title, double salary)
        {
            //try
            //{
               Positions.Add(new Position()
                {
                   Title=title,
                   Salary=salary
                });
                SaveChanges();
                return "Запись добавлена!";
            //}
            //catch (Exception ex) { return ex.Message; }
        }
        public string AddProduct(string title, double price, string photo, int ID_productType)
        {
            try
            {
                Product product = new Product()
                {
                    Title = title,
                    Price = price,
                    Photo = photo,
                    Product_TypeID = ID_productType
                };
                Products.Add(product);
                Product_Types.FirstOrDefault(i => i.Product_TypeID == ID_productType).Product.Add(product);
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        ////public string AddProduct_Of_Request(int ID_request, double price, int ID_product, int quantity)
        //{
        //    try
        //    {
        //        Product_Of_Request product_ = new Product_Of_Request()
        //        {
        //            ID_Product =ID_product,
        //            Price = price,
        //            ID_Request = ID_request,
        //            Quantity = quantity
        //        };
        //        Product_Of_Requests.Add(product_);
        //        Products.FirstOrDefault(i => i.ID_Product == ID_product).Product_Of_Request.Add(product_);
        //        SaveChanges();
        //        return "Запись добавлена!";
        //    }
        //    catch (Exception ex) { return ex.Message; }
        //}


    }
}