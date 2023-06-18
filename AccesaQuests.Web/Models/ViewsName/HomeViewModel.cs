using AccesaQuests.Web.Models.Domain;

namespace AccesaQuests.Web.Models.ViewsName
{
    public class HomeViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public string CurrentTag { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
