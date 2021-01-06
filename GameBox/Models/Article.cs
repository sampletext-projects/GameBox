using System.ComponentModel.DataAnnotations.Schema;

namespace GameBox.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string HtmlContent { get; set; }

        public string ShortDescription { get; set; }

        public string Title { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}