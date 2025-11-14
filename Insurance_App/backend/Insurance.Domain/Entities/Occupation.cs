namespace Insurance.Domain.Entities
{
    public class Occupation
    {
    public int Id { get; set; }
    public string OccupationName { get; set; } = null!;
    public string Rating { get; set; } = null!;
    public decimal RatingFactor { get; set; }
    }
}