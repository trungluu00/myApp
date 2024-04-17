using myApp.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace myApp.Cloud.Controllers.API
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IFollowService _followService;

        public UserController(
            IUserService userService,
            IFollowService followService
        )
        {
            _userService = userService;
            _followService = followService;
        }

        [HttpGet]
        public IHttpActionResult GetData()
        {
            var data = _followService.Gets();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Create(string name)
        {
            _followService.Create(name);

            return Ok();
        }

        ~UserController() { }
    }
}