using System.ComponentModel.DataAnnotations;

namespace AccesaQuests.Web.Models.ViewsName
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get;set; }
        [Required]
        [MinLength(6 ,ErrorMessage = "Password has to be at least 6 characthers")]
        public string Password { get;set; }

    }
}
