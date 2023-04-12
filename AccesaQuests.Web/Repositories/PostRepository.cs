using AccesaQuests.Web.Data;
using AccesaQuests.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AccesaQuests.Web.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AccesaQuestsDbContext accesaQuestsDbContext;

        public PostRepository(AccesaQuestsDbContext accesaQuestsDbContext   )
        {
            this.accesaQuestsDbContext = accesaQuestsDbContext;
        }
        public async Task<Post> AddAsync(Post post)
        {
            await accesaQuestsDbContext.AddAsync(post);
            await accesaQuestsDbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> DeleteAsync(Guid id)
        {
            var existingPost =await accesaQuestsDbContext.Posts.FindAsync(id);
            if (existingPost != null)
            {
                accesaQuestsDbContext.Posts.Remove(existingPost);
                await accesaQuestsDbContext.SaveChangesAsync();
                return existingPost;
            }
            return null;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await accesaQuestsDbContext.Posts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<Post?> GetAsync(Guid id)
        {
           return await accesaQuestsDbContext.Posts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post?> GetByUrlHandleAsync(string urlHandle)
        {
           return await accesaQuestsDbContext.Posts.Include(x => x.Tags)
                .FirstOrDefaultAsync(x =>x.UrlHandle == urlHandle);
        }

        public async Task<Post?> UpdateAsync(Post post)
        {
            var existingPost = await accesaQuestsDbContext.Posts.Include(x => x.Tags).
                FirstOrDefaultAsync(x => x.Id == post.Id);
            if(existingPost != null)
            {
                existingPost.Id = post.Id;
                existingPost.PostHeading = post.PostHeading;
                existingPost.PostTitle = post.PostTitle;
                existingPost.Content = post.Content;
                existingPost.ShortDescription = post.ShortDescription;
                existingPost.Author = post.Author;
                existingPost.FeaturedImageUrl = post.FeaturedImageUrl;
                existingPost.UrlHandle = post.UrlHandle;
                existingPost.PublishedDate = post.PublishedDate;
                existingPost.Visible = post.Visible;
                existingPost.Tags = post.Tags;

                await accesaQuestsDbContext.SaveChangesAsync();
                return existingPost;
            }
            return null;
        }
    }
}
