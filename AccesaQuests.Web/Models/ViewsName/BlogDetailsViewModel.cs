﻿using AccesaQuests.Web.Models.Domain;

namespace AccesaQuests.Web.Models.ViewsName
{
    public class BlogDetailsViewModel
    {
        public Guid Id { get; set; }
        public string PostHeading { get; set; }
        public string PostTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public int TotalLikes { get; set; }

    }
}
