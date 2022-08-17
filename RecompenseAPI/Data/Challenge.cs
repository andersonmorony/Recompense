namespace RecompenseAPI.Data
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; } = false;
        public int MyProperty { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
