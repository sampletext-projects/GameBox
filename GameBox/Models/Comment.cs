using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameBox.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int Mark { get; set; }

        public string Content { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}