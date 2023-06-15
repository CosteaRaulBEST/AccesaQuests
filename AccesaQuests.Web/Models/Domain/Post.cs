
namespace AccesaQuests.Web.Models.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string PostHeading { get; set; }
        public string PostTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get;set; }
        public bool Visible { get; set; }

        //Navigation property
        public ICollection<Tag> Tags { get; set; }
        public ICollection<BlogPostLike> Likes { get; set; }
        public ICollection<BlogPostComment> Comments { get; set; }


    }
}
