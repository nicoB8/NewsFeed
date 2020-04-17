using System;
using System.ComponentModel.DataAnnotations;

namespace newsfeed.nicolasbonora.entities.Base_entities
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
