using newsfeed.nicolasbonora.entities.Base_entities;

namespace newsfeed.nicolasbonora.entities
{
    public interface IPost : IBaseEntity
    {
        Feed Feed { get; set; }
        string ContentHeader { get; set; }
    }
}
