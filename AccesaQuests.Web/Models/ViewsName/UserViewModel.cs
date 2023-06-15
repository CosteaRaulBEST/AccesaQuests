namespace AccesaQuests.Web.Models.ViewsName
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }

        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool AdminRoleCheckbox { get; set; }
    }
}
