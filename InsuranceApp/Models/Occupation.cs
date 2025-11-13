namespace InsuranceApp.Models
{
    public class Occupation
    {
        public int Id { get; set; }
        public string? OccupationName { get; set; }
        public string? Rating { get; set; }
        public decimal RatingFactor { get; set; }
    }
}