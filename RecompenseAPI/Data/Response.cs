using System.ComponentModel.DataAnnotations;

namespace RecompenseAPI.Data
{
    public class Response
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool isCorrect { get; set; }
    }
}
