using System;
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

        public Game()
        {
        }
    }
}