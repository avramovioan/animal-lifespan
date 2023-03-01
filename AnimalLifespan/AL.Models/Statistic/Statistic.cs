using AnimalLifespan.Enums;

namespace AnimalLifespan.Models
{
    public class Statistic
    {
        public AnimalType AnimalType { get; set; }
        public int AnimalCount { get; set; }
        public int MaximumLifespan { get; set; }
        public int MinimumLifespan { get; set; }
        public double AverageLifespan { get; set; }
    }
}