using System.Collections.Generic;

namespace CourseCinema.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public double Rating { get; set; }

        public double AverageRating
        {
            get
            {
                if (Reviews == null || Reviews.Count == 0)
                {
                    return 0;
                }
                return Reviews.Average(r => r.Rating);
            }
        }
    }
}
