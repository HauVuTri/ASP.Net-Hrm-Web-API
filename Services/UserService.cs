using HRMAspNet.Common;
using HRMAspNet.Interfaces;
using HRMAspNet.Models;
using HRMAspNet.Models.Authencicate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRMAspNet.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //Check thông tin request gửi lên xem có user nào có trùng usernaem và password nưh vậy không
            using (HRMContext context = new HRMContext())
            {
                var user = context.User.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                // return null if user not found
                if (user == null) return null;

                // authentication successful so generate jwt token
                var token = generateJwtToken(user);

                return new AuthenticateResponse(user, token);

            }
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);


        }

        public  List<User> GetAll()
        {
            using (HRMContext context = new HRMContext())
            {
                return  context.User.ToList();
            }
        }

        public User GetById(Guid id)
        {
            using (HRMContext context = new HRMContext())
            {
                return context.User.FirstOrDefault(x => x.UserId == id);
            }
            
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
