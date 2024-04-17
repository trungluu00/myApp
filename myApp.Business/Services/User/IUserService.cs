using myApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Business.Services
{
    public interface IUserService
    {
        User GetUserId(int Id);
        User GetByName(string Name);
        IEnumerable<User> GetAllUsers();
    }
}
