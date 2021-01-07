using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameBox.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        public string ImgUrl { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}