using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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





        [Required(ErrorMessage = "Powtórz email")]
        [DataType(DataType.EmailAddress)]
        [Compare("UserEmailAddress",ErrorMessage ="Emaile nie są takie same")]
        public string ConfirmEmailAddress { get; set; }



        [Required(ErrorMessage = "Hasło jest wymagane!!")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [NotMapped]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage ="Hasło nie spełnia wymagań")]
        public string UserPassword { get; set; }



        //[Required(ErrorMessage = "Pole wymagane!!")]
        [Compare("UserPassword",ErrorMessage ="Hasła nie są takie same")]
        [DataType(DataType.Password)]
        [NotMapped]
        [MaxLength(20)]
//        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Hasło nie spełnia wymagań")]
        public string ConfirmPassword { get; set; }




        public string Source { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }
        public DateTime? LastEditDate { get; set; }
        public byte RoleId { get; set; }
        public Role Role { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
       
    }
}
