namespace MyLetterBoxd.Models
{
    public class User
    {
        public int ID { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public required string Password { get; set; }
        public ICollection<UserEntertainment> UserEntertainments { get; set; } = new List<UserEntertainment>();
    }
}

