using System.ComponentModel.DataAnnotations;

namespace GamepageWebApplication.Models
{
    public class GameViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Game Name")]
        public string Name { get; set; }

        public bool IsAdmin { get; set; }

    }
}
