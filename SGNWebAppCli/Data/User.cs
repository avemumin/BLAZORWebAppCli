using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGNWebAppCli.Data
{
    public class User
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserPassword { get; set; }
        public string Source { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? LastEditDate { get; set; }
        public byte Role { get; set; }


        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
