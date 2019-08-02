using aspnetcoreioc.IService;
using aspnetcoreioc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreioc.Service
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            return new List<User> {
                new User {Id=1,Name="sands"}
            };
        }
    }
}
