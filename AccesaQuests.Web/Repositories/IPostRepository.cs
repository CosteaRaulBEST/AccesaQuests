using AccesaQuests.Web.Models.Domain;

namespace AccesaQuests.Web.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post?> GetAsync(Guid id);
        Task<Post?> GetByUrlHandleAsync(string urlHandle);
        Task<Post> AddAsync(Post post);
        Task<Post?> UpdateAsync(Post post);
        Task<Post?> DeleteAsync(Guid id);

    }
}
