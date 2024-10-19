using System.ComponentModel.DataAnnotations;

namespace ShowTracker.Models
{
    public class Show
    {
        public int ShowId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }
    }
}
