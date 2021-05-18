using HRMAspNet.Common;
using HRMAspNet.Controllers.BaseController;
using HRMAspNet.Interfaces;
using HRMAspNet.Interfaces.BaseInterface;
using HRMAspNet.Models;
using HRMAspNet.Models.Authencicate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User>
    {

        private IUserService _userService;
        //public UsersController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public UsersController(IBase<User> iBase, IUserService userService) : base(iBase)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [Authorize]
        [HttpGet("getallUser")]
        public List<User> GetAll()
        {
            return  _userService.GetAll();
        }
    }
}
