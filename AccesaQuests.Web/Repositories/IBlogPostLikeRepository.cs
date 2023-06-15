    using AccesaQuests.Web.Models.Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace AccesaQuests.Web.Repositories
    {
        public interface IBlogPostLikeRepository
        {
            Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);
            Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);
            Task<int> GetTotalLikes(Guid blogPostId);
        }
    }
