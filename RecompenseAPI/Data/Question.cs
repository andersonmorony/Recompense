using System.ComponentModel.DataAnnotations.Schema;

namespace RecompenseAPI.Data
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool isActive { get; set; } = false;
        public int ChallengeId { get; set; }
        public ICollection<Response> Responses { get; set; }

    }
}
