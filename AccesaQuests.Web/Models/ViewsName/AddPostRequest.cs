using AccesaQuests.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AccesaQuests.Web.Models.ViewsName
{
    public class AddPostRequest
    {
        [Required]
        public string PostHeading { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string FeaturedImageUrl { get; set; }
        [Required]
        public string UrlHandle { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public bool Visible { get; set; }

        //Display Tags  
            public IEnumerable<SelectListItem> Tags { get; set; }

            //Collect Tag
            public string[] SelectedTags { get; set; } = Array.Empty<string>();

    }
}
