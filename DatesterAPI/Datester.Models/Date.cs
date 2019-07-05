using System;

namespace Datester.Data.Models
{
    using System.Collections.Generic;
    using Datester.Models;

    public class Date
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<UsersDates> Users { get; set; }

        public Date()
        {
            this.Users = new HashSet<UsersDates>();
        }
    }
}
