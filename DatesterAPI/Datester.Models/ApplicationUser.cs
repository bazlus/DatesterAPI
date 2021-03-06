﻿namespace Datester.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Datester.Models;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<string>
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
        public ICollection<UserOperations> UserOperations { get; set; }

        public string Hobbies { get; set; }

        public ICollection<UsersPhotos> Photos { get; set; }

        public DateTime BirthDate { get; set; }

        public ApplicationUser()
        {
            this.UserOperations = new HashSet<UserOperations>();
            this.Dates = new HashSet<UsersDates>();
            this.Photos = new HashSet<UsersPhotos>();
        }
    }
}
