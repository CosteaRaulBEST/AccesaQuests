using AccesaQuests.Web.Data;
using AccesaQuests.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AccesaQuests.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AccesaQuestsDbContext accesaQuestsDbContext;

        public TagRepository(AccesaQuestsDbContext accesaQuestsDbContext)
        {
            this.accesaQuestsDbContext = accesaQuestsDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await accesaQuestsDbContext.Tags.AddAsync(tag);
            await accesaQuestsDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await accesaQuestsDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                accesaQuestsDbContext.Tags.Remove(existingTag);
                await accesaQuestsDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }
        
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await accesaQuestsDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return accesaQuestsDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await accesaQuestsDbContext.Tags.FindAsync(tag.Id);
            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await accesaQuestsDbContext.SaveChangesAsync();

                return existingTag;
            }
            return null;
        }
    }
}
