using System;
using System.Collections.Generic;
using System.Text;

namespace Datester.Data.Models
{
    public class UsersPhotos
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string PhotoUrl { get; set; }
    }
}
