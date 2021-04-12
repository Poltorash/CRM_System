namespace CRM.Context
{
    using CRM.Model;
    using CRM.Model.DbModels;
    using System;
    using System.Collections.Generic;
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
                Requests.FirstOrDefault(i => i.RequestID == ID_request).Product_Of_Requests.Add(product_);
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
        public string AddRequest(DateTime dateRequest, int clientID)
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
                    StatusRequest=StatusRequest.Обработан,
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
        public string AddUser(string userLogin, string userPassword) 
        {
            try
            {
                Users.Add(new User()
                {
                    UserLogin = userLogin,
                    UserPassword = userPassword,
                    UserStatus=UserStatus.Пользователь
                });
                SaveChanges();
                return "Запись добавлена!";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string EditClient(int id,string title, string lastName, string firstName, string patronymic, string phone, string contract, string addressCompany, string photo)
        {
            try
            {
                var item = Clients.FirstOrDefault(i=>i.ClientID == id);
                if (contract != "" && item.ClientStatus != Tag.Постоянный_клиент) item.ClientStatus = Tag.Договор;
                item.TitleCompany = title;
                item.LastName = lastName;
                item.FirstName = firstName;
                item.Patronymic = patronymic;
                item.Phone = phone;
                item.AddressCompany = addressCompany;
                item.ContractPath = contract;
                item.Photo = photo;
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditEmployee(int id,string lastName, string firstName, string patronymic, string phone, int ID_position)
        {
            try
            {
                var item = Employees.FirstOrDefault(i=>i.EmployeeID == id);
                Positions.FirstOrDefault(i => i.PositionID == item.PositionID).Employee.Remove(item);
                item.LastName = lastName;
                item.FirstName = firstName;
                item.Patronymic = patronymic;
                item.Phone = phone;
                item.PositionID = ID_position;
                Positions.FirstOrDefault(i => i.PositionID == ID_position).Employee.Add(item);
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditPosition(int id,string title, double salary)
        {
            try
            {
                var item = Positions.FirstOrDefault(i=>i.PositionID == id);
                item.Title = title;
                item.Salary = salary;
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditProduct(int id,string title, double price, string photo, int ID_productType)
        {
            try
            {
                var item = Products.FirstOrDefault(i=>i.ProductID == id);
                Product_Types.FirstOrDefault(i => i.Product_TypeID == item.Product_TypeID).Product.Remove(item);
                item.Title = title;
                item.Price = price;
                item.Photo = photo;
                item.Product_TypeID = ID_productType;
                Product_Types.FirstOrDefault(i => i.Product_TypeID == ID_productType).Product.Add(item);
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditProduct_Type(int id,string title)
        {
            try
            {
                var item = Product_Types.FirstOrDefault(i=>i.Product_TypeID == id);
                item.Title = title;
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditProvider(int id,string titleCompany, string lastName, string firstName, string patronymic, string phone, string photo)
        {
            try
            {
               var item = Providers.FirstOrDefault(i=>i.ProviderID == id);
                item.TitleCompany = titleCompany;
                item.LastName = lastName;
                item.FirstName = firstName;
                item.Patronymic = patronymic;
                item.Phone = phone;
                item.Photo = photo;
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditProvider_Product(int id,string title, double price)
        {
            try
            {
                var item = Provider_Products.FirstOrDefault(i=>i.Provider_ProductID == id);
                item.Title = title;
                item.Price = price;
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditRequestStatus(int id)
        {
            try
            {
                var status = Requests.FirstOrDefault(i => i.RequestID == id);
                if (status.StatusRequest == StatusRequest.Выполнен) return "Заявка уже выполнена";
                else status.StatusRequest++;
                return "Статус изменен!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditShipment(int id,DateTime dateShipment, int clientID, int employeeID, int? requestID)
        {
            try
            {
                var item = Shipments.FirstOrDefault(i=>i.ShipmentID == id);
                Clients.FirstOrDefault(i => i.ClientID == item.ClientID).Shipment.Remove(item);
                Employees.FirstOrDefault(i => i.EmployeeID == item.EmployeeID).Shipment.Remove(item);
                Requests.FirstOrDefault(i => i.RequestID == item.RequestID).Shipment.Remove(item);
                item.DateShipment = dateShipment;
                item.ClientID = clientID;
                item.EmployeeID = employeeID;
                item.RequestID = requestID;
                Clients.FirstOrDefault(i => i.ClientID == clientID).Shipment.Add(item);
                Employees.FirstOrDefault(i => i.EmployeeID == employeeID).Shipment.Add(item);
                Requests.FirstOrDefault(i => i.RequestID == requestID).Shipment.Add(item);
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditStock(int id,int quantity, int productID)
        {
            try
            {
                var item = Stocks.FirstOrDefault(i=>i.StockID == id);
                Products.FirstOrDefault(i => i.ProductID == item.ProductID).Stock.Remove(item);
                item.ProductID = productID;
                item.Quantity = quantity;
                Products.FirstOrDefault(i => i.ProductID == productID).Stock.Add(item);
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditSupply(int id,DateTime dateSupply, double price, int provider_ProductID, int employeeID, int providerID)
        {
            try
            {
                var item = Supplys.FirstOrDefault(i=>i.SupplyID == id);
                Providers.FirstOrDefault(i => i.ProviderID == item.ProviderID).Supply.Remove(item);
                Employees.FirstOrDefault(i => i.EmployeeID == item.EmployeeID).Supply.Remove(item);
                Provider_Products.FirstOrDefault(i => i.Provider_ProductID == item.Provider_ProductID).Supply.Remove(item);
                item.DateSupply = dateSupply;
                item.Price = price;
                item.EmployeeID = employeeID;
                item.Provider_ProductID = provider_ProductID;
                item.ProviderID = providerID;
                Providers.FirstOrDefault(i => i.ProviderID == providerID).Supply.Add(item);
                Employees.FirstOrDefault(i => i.EmployeeID == employeeID).Supply.Add(item);
                Provider_Products.FirstOrDefault(i => i.Provider_ProductID == provider_ProductID).Supply.Add(item);
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string EditUser(int id,string userLogin, string userPassword,UserStatus userStatus)
        {
            try
            {
                var item = Users.FirstOrDefault(i=>i.UserID == id);
                item.UserLogin = userLogin;
                item.UserPassword = userPassword;
                item.UserStatus = userStatus ;
                SaveChanges();
                return "Запись отредактирована!";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public string RemoveClient(int id)
        {
            try
            {
                var item = Clients.FirstOrDefault(i => i.ClientID == id);
                Clients.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveEmployee(int id)
        {
            try
            {
                var item = Employees.FirstOrDefault(i => i.EmployeeID == id);
                Positions.FirstOrDefault(i => i.PositionID == item.PositionID).Employee.Remove(item);
                Employees.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemovePosition(int id)
        {
            try
            {
                var item = Positions.FirstOrDefault(i => i.PositionID == id);
                Positions.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveProduct(int id) //???? 
        {
            try
            {
                var item = Products.FirstOrDefault(i => i.ProductID == id);
                var itemPR = Product_Of_Requests.Where(i => i.ProductID == id);
                Product_Of_Requests.RemoveRange(itemPR);
                Product_Types.FirstOrDefault(i => i.Product_TypeID == item.Product_TypeID).Product.Remove(item);
                Products.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveProduct_Type(int id)
        {
            try
            {
                var item = Product_Types.FirstOrDefault(i => i.Product_TypeID == id);
                Product_Types.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveProvider(int id)
        {
            try
            {
                var item = Providers.FirstOrDefault(i => i.ProviderID == id);
                Providers.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveProvider_Product(int id)
        {
            try
            {
                var item = Provider_Products.FirstOrDefault(i => i.Provider_ProductID == id);
                Provider_Products.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveRequest(int id) //???? 
        {
            try
            {
                var item = Requests.FirstOrDefault(i => i.RequestID == id);
                if (item.DateRequest < DateTime.Now.AddYears(-1))
                {
                    var itemPR = Product_Of_Requests.Where(i => i.RequestID == id);
                    Product_Of_Requests.RemoveRange(itemPR);
                    Requests.Remove(item);
                    SaveChanges();
                    return "Запись удалена!";
                }
                else return "Невозможно удалить зявку, так как заявка существует меньше года";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveShipment(int id)
        {
            try
            {
                var item = Shipments.FirstOrDefault(i => i.ShipmentID == id);
                Clients.FirstOrDefault(i => i.ClientID == item.ClientID).Shipment.Remove(item);
                Employees.FirstOrDefault(i => i.EmployeeID == item.EmployeeID).Shipment.Remove(item);
                Requests.FirstOrDefault(i => i.RequestID == item.RequestID).Shipment.Remove(item);
                Shipments.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveStock(int id)
        {
            try
            {
                var item = Stocks.FirstOrDefault(i => i.StockID == id);
                Products.FirstOrDefault(i => i.ProductID == item.ProductID).Stock.Remove(item);
                Stocks.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoveSupply(int id)
        {
            try
            {
                var item = Supplys.FirstOrDefault(i => i.SupplyID == id);
                Providers.FirstOrDefault(i => i.ProviderID == item.ProviderID).Supply.Remove(item);
                Employees.FirstOrDefault(i => i.EmployeeID == item.EmployeeID).Supply.Remove(item);
                Provider_Products.FirstOrDefault(i => i.Provider_ProductID == item.Provider_ProductID).Supply.Remove(item);
                Supplys.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public string RemoceUser(int id)
        {
            try
            {
                var item = Users.FirstOrDefault(i => i.UserID == id);
                int count = Users.Where(i => i.UserStatus == UserStatus.Администратор).Count();
                if (item.UserStatus == UserStatus.Администратор && count == 1) return "Нельзя удалить последнего администратора";
                Users.Remove(item);
                SaveChanges();
                return "Запись удалена!";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public Client GetClient(int id) => Clients.FirstOrDefault(i=>i.ClientID == id);
        public List<Product> GetAllProduct() => Products.ToList();
        public List<Client> GetAllClient() => Clients.ToList();
    }
}