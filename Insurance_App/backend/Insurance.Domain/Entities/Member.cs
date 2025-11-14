namespace Insurance.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int AgeNextBirthday { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int OccupationId { get; set; }
        public decimal DeathSumInsured { get; set; }
        public decimal MonthlyPremium { get; set; }


        public Occupation? Occupation { get; set; }
    }
}