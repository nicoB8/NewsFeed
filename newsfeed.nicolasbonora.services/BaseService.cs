using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using newsfeed.nicolasbonora.repository;

namespace newsfeed.nicolasbonora.services
{
    public abstract class BaseService : IBaseService
    {
        protected readonly NewsFeedContext _context;

        public BaseService(NewsFeedContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                //Should log it
                throw ex;
            }
        }
    }
}
