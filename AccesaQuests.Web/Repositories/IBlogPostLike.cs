namespace AccesaQuests.Web.Repositories
{
    public interface IBlogPostLike
    {
        Task<int> GetTotalLikes(Guid blogPostId);
    }
}
