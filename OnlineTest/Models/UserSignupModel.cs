namespace OnlineTest.Models
{
    public class UserSignupModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
