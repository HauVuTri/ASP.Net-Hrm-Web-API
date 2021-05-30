using System;
using System.Collections.Generic;

namespace HRMAspNet.Models
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string UserCode { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
