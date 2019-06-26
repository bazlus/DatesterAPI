using System;

namespace Datester.Data.Models
{
    public class Date
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string FirstUserId { get; set; }
        public User FirstUser { get; set; }

        public string SecondUserId { get; set; }
        public User SecondUser { get; set; }
    }
}
