using System.ComponentModel.DataAnnotations;

namespace AccesaQuests.Web.Models.ViewsName
{
    public class RegisterViewModel
    {
        [Required] 
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6 ,ErrorMessage ="Password has to be eat least 6 characthers")]
        public string Password { get; set;}
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
