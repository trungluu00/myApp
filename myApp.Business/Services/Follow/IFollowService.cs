using myApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Business.Services
{
    public interface IFollowService : IDisposable
    {
        Follow GetById(int Id);
        IEnumerable<Follow> Gets();
        void Create(string name);
    }
}
