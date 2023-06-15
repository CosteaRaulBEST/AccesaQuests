    using AccesaQuests.Web.Data;
    using AccesaQuests.Web.Models.Domain;
    using Microsoft.EntityFrameworkCore;

    namespace AccesaQuests.Web.Repositories
    {
        public class BlogPostLikeRepository : IBlogPostLikeRepository
        {
            private readonly AccesaQuestsDbContext accesaQuestsDbContext;

            public BlogPostLikeRepository(AccesaQuestsDbContext accesaQuestsDbContext)
            {
                this.accesaQuestsDbContext = accesaQuestsDbContext;
            }

            public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
            {
                await accesaQuestsDbContext.BlogPostLike.AddAsync(blogPostLike);
                await accesaQuestsDbContext.SaveChangesAsync();
                return blogPostLike;
            }

            public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
            {
                return await accesaQuestsDbContext.BlogPostLike
                    .Where(x => x.BlogPostId == blogPostId)
                    .ToListAsync();
            }

            public async Task<int> GetTotalLikes(Guid blogPostId)
            {
                return await accesaQuestsDbContext.BlogPostLike
                    .CountAsync(x => x.BlogPostId == blogPostId);
            }
        }
    }
