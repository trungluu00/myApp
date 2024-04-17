using myApp.DataAccess.Entities;
using myApp.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.Business.Services
{
    public class FollowService : ServiceBase, IFollowService
    {
        private readonly IRepository<Follow> _followRepository;

        public FollowService(IDbContext context)
            : base(context)
        {
            _followRepository = Context.GetRepository<Follow>();
        }

        public void Create(string name)
        {
            var follow = new Follow()
            {
                Account = name
            };

            _followRepository.Insert(follow);
        }

        public Follow GetById(int Id)
        {
            return _followRepository.Get(Id);
        }

        public IEnumerable<Follow> Gets()
        {
            return _followRepository.Gets(true);
        }
    }
}
