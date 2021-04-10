namespace CRM.Context
{
    using CRM.Model;
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
        public virtual DbSet<Product_Of_Request> Product_Of_Requests { get; set; }

        public string AddClient(string title, string lastName, string firstName, string patronymic, string phone, string addressCompany, string photo) 
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
                    ClientStatus = Model.Tag.Заинтересованы,
                    ContractPath = "",
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
            try
            {
                Positions.Add(new Position()
                {
                   Title=title,
                   Salary=salary
                });
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
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
        public string AddProduct_Of_Request(int ID_request, double sum, int ID_product, int quantity)
        {
            try
            {
                Product_Of_Request product_ = new Product_Of_Request()
                {
                    ProductID = ID_product,
                    Sum = sum,
                    RequestID = ID_request,
                    Quantity = quantity
                };
                Product_Of_Requests.Add(product_);
                Products.FirstOrDefault(i => i.ProductID == ID_product).Product_Of_Requests.Add(product_);
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddProduct_Type(string title) 
        {
            try
            {
                Product_Types.Add(new Product_Type()
                {
                    Title = title
                });
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddProvider(string titleCompany, string lastName, string firstName, string patronymic, string phone, string photo)
        {
            try
            {
                Providers.Add(new Provider()
                {
                    TitleCompany = titleCompany,
                    LastName=lastName,
                    FirstName=firstName,
                    Patronymic=patronymic,
                    Phone=phone,
                    Photo=photo
                });
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddProvider_Product(string title, double price)
        {
            try
            {
                Provider_Products.Add(new Provider_Product()
                {
                    Title = title,
                    Price=price
                });
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddRequest(DateTime dateRequest, StatusRequest statusRequest, int clientID)
        {
            try
            {
                var client = Clients.FirstOrDefault(i => i.ClientID == clientID);
                if (client.Request.Count == 1) client.ClientStatus = Tag.Дегустация;
                else if (client.Request.Count == 5 && client.ClientStatus != Tag.Договор) 
                    return "Оформите договор на поставку товара для дальнейшей работы";
                Request request = new Request()
                {
                    DateRequest=dateRequest,
                    StatusRequest=statusRequest,
                    ClientID=clientID
                };
                Requests.Add(request);                
                client.Request.Add(request);                
                if (client.Request.Count == 10) client.ClientStatus = Tag.Постоянный_клиент;
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddShipment(DateTime dateShipment, int clientID, int employeeID, int? requestID)
        {
            try
            {
                Shipment shipment = new Shipment()
                {
                    DateShipment = dateShipment,
                    ClientID = clientID,
                    EmployeeID = employeeID,
                    RequestID = requestID
                };
                Shipments.Add(shipment);
                Clients.FirstOrDefault(i => i.ClientID == clientID).Shipment.Add(shipment);
                Employees.FirstOrDefault(i => i.EmployeeID == employeeID).Shipment.Add(shipment);
                Requests.FirstOrDefault(i => i.RequestID == requestID).Shipment.Add(shipment);
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddStock(int quantity, int productID)
        {
            try
            {
                Stock stock = new Stock()
                {
                    ProductID = productID,
                    Quantity = quantity
                };
                Stocks.Add(stock);
                Products.FirstOrDefault(i => i.ProductID == productID).Stock.Add(stock);
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string AddSupply(DateTime dateSupply, double price, int provider_ProductID, int employeeID, int providerID)
        {
            try
            {
                Supply supply = new Supply()
                {
                    DateSupply = dateSupply,
                    Price = price,
                    EmployeeID = employeeID,
                    Provider_ProductID = provider_ProductID,
                    ProviderID=providerID
                };
                Supplys.Add(supply);
                Providers.FirstOrDefault(i => i.ProviderID == providerID).Supply.Add(supply);
                Employees.FirstOrDefault(i => i.EmployeeID == employeeID).Supply.Add(supply);
                Provider_Products.FirstOrDefault(i => i.Provider_ProductID == provider_ProductID).Supply.Add(supply);
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        //Как добавят статусы ему изменить метод!!!
        public string AddUser(string userLogin, string userPassword, UserStatus userStatus) 
        {
            try
            {
                Users.Add(new User()
                {
                    UserLogin = userLogin,
                    UserPassword = userPassword,
                    UserStatus=userStatus
                });
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}