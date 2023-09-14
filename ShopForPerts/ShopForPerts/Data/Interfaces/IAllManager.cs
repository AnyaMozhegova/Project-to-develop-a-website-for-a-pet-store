using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Interfaces
{
    public interface IAllManager
    {
        void AddUser(Manager manager);
        bool IsEmailExists(string email);
    }
}
