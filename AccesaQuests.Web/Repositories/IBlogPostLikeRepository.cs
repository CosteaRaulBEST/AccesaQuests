using AccesaQuests.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Repositories
{
    public class IBlogPostLikeRepository : IBlogPostLike
    {
        private readonly AccesaQuestsDbContext accesaQuestsDbContext;
        public IBlogPostLikeRepository(AccesaQuestsDbContext accesaQuestsDbContext)
        {
            this.accesaQuestsDbContext = accesaQuestsDbContext;
        }
        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await accesaQuestsDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
