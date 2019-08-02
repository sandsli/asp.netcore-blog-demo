using aspnetcoreioc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoreioc.IService;

namespace aspnetcoreioc.Service
{
    public class AdminService : IUserService
    {
        public List<User> GetUsers()
        {
            return new List<User> {
                new User {Id=2,Name="admin"}
            };
        }
    }
}
