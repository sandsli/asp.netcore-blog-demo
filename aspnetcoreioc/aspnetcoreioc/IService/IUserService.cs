using aspnetcoreioc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreioc.IService
{
   public interface IUserService
    {
        List<User> GetUsers();
    }
}
