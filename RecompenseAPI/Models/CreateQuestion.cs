using RecompenseAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace RecompenseAPI.Models
{
    public class CreateQuestion
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool isActive { get; set; } = false;
        public int ChallengeId { get; set; }
    }
}
