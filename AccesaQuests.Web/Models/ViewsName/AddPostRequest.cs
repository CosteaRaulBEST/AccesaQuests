using AccesaQuests.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccesaQuests.Web.Models.ViewsName
{
    public class AddPostRequest
    {
        public string PostHeading { get; set; }
        public string PostTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

            //Display Tags
            public IEnumerable<SelectListItem> Tags { get; set; }

            //Collect Tag
            public string[] SelectedTags { get; set; } = Array.Empty<string>();

    }
}
