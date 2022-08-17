using System.ComponentModel.DataAnnotations;

namespace RecompenseAPI.Models
{
    public class CreateChallenge
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; } = false;
    }
}
