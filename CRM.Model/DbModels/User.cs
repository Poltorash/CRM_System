using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.DbModels
{
   public class User
    {
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserStatus { get; set; }
    }
}
