using HRMAspNet.Models;
using HRMAspNet.Models.Authencicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        public List<User> GetAll();
        //IEnumerable<User> GetAll();
        //User GetById(int id);
        public User GetById(Guid id);
    }
}
