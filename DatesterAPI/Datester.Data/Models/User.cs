using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Datester.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public Gender Gender { get; set; }

        public Gender InterestedIn { get; set; }

        public ICollection<Date> Dates { get; set; }
    }
}
