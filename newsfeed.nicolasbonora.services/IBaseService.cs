using System.Threading.Tasks;

namespace newsfeed.nicolasbonora.services
{
    public interface IBaseService
    {
        Task<bool> SaveChangesAsync();
    }
}
