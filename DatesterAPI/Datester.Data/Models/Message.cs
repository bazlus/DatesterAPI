using System;
using System.ComponentModel.DataAnnotations;

namespace Datester.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public string Text { get; set; }

        public int ChatId { get; set; }

        public Chat Chat { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
