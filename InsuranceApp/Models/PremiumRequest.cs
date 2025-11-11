namespace InsuranceApp.Models
{
    public class PremiumRequest
    {
        public string? Name { get; set; }
        public int AgeNextBirthday { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int OccupationId { get; set; }
        public decimal DeathSumInsured { get; set; }
    }
}