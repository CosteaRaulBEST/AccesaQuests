using Microsoft.AspNetCore.Identity;

namespace AccesaQuests.Web.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
