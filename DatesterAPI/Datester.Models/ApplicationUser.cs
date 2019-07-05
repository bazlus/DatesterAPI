namespace Datester.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Datester.Models;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Gender InterestedIn { get; set; }

        public ICollection<UsersDates> Dates { get; set; }

        [InverseProperty("UserOne")]
        public ICollection<UserOperations> UserOperationses { get; set; }


        public ApplicationUser()
        {
            this.UserOperationses = new HashSet<UserOperations>();
            this.Dates = new HashSet<UsersDates>();
        }
    }
}
