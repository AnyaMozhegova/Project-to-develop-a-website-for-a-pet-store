﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Interfaces
{
   public interface IUserService
    {
        void AddUser(DataForUser user);
        bool IsEmailExists(string email);
    }
}
