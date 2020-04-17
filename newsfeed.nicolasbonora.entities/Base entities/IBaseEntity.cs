using System;

namespace newsfeed.nicolasbonora.entities.Base_entities
{
    public interface IBaseEntity
    {
        string Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
