using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public enum Tag
    {
        Заинтересованы,
        Дегустация,    
        Договор,
        Постоянный_клиент
    }
    public enum StatusRequest 
    { 
        Обработан,
        Отправлен,
        Выполнен
    }
    public enum UserStatus 
    {
        Администратор,
        Пользователь
    }
}
