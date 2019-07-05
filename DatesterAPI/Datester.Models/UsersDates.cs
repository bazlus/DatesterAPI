namespace Datester.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class UsersDates
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int DateId { get; set; }
        public Date Date { get; set; }
    }
}
