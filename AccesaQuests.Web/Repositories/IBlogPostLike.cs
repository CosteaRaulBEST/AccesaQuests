namespace BlogPost.Repositories
{
    public interface IBlogPostLike
    {
        Task<int> GetTotalLikes(Guid blogPostId);
    }
}
