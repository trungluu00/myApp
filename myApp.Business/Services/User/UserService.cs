using myApp.DataAccess.Entities;
using myApp.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Business.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IDbContext context)
            : base(context)
        {
            _userRepository = Context.GetRepository<User>();
        }

        public DataAccess.Entities.User GetUserId(int Id)
        {
            return _userRepository.Get(Id);
        }

        public IEnumerable<DataAccess.Entities.User> GetAllUsers()
        {
            return _userRepository.Gets(true);
        }

        public User GetByName(string Name)
        {
            return _userRepository.Gets(true, u => u.Name == Name).FirstOrDefault();
        }
    }
}
