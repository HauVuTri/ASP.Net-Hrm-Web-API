using System;

namespace HRMAspNet.Models.Authencicate
{
    public class AuthenticateResponse
    {
        public Guid UserId { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            UserId = user.UserId;
            UserCode = user.UserCode;
            FullName = user.FullName;
            Username = user.Email;
            Token = token;
        }
    }
}