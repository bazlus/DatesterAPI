namespace Datester.Data.Models
{
    public class UserChat
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
