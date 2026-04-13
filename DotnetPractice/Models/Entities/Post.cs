using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetPractice.Models.Entities
{
    public class Post
    {
        [Key]
        public Guid GUID { get; set; }
        public Guid UserGUID { get; set; }
        public Guid CategoryGUID { get; set; }
        public string PostText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Post(Guid userGUID, Guid categoryGUID, string postText)
        {
            GUID = Guid.NewGuid();
            UserGUID = userGUID;
            CategoryGUID = categoryGUID;
            PostText = postText;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
