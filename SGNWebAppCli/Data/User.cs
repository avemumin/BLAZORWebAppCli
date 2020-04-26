using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGNWebAppCli.Data
{
    public class User
    {
        public int IdUser { get; set; }

        [Required (ErrorMessage = "Imię jest wymagane")]
        [MaxLength(128,ErrorMessage ="Imię jest za długie")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(128, ErrorMessage = "Nazwisko jest za długie")]
        public string UserLastName { get; set; }

        [Required (ErrorMessage ="Podaj email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "To nie jest poprawny email")]
        public string UserEmailAddress { get; set; }

        
        public string UserPassword { get; set; }
        public string Source { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }
        public DateTime? LastEditDate { get; set; }
        public byte Role { get; set; }


        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string ConfirmPassword { get; set; }
        public User()
        {

        }
       
    }
}
