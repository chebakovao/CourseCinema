namespace CourseCinema.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}
