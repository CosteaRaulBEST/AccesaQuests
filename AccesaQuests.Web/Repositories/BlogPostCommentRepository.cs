using AccesaQuests.Web.Data;
using AccesaQuests.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AccesaQuests.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly AccesaQuestsDbContext accesaQuestsDbContext;
        public BlogPostCommentRepository(AccesaQuestsDbContext accesaQuestsDbContext)
        {
            this.accesaQuestsDbContext = accesaQuestsDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostcomment)
        {
            await accesaQuestsDbContext.BlogPostComment.AddAsync(blogPostcomment);
            await accesaQuestsDbContext.SaveChangesAsync();
            return blogPostcomment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
           return await accesaQuestsDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
