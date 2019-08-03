using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatesterAPI.ViewModels
{
    using Datester.Data.Models;

    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Hobbies { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public UsersPhotos[] Photos { get; set; }
    }
}
