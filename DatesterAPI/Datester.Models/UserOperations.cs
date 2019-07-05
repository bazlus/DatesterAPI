using System;
using System.Collections.Generic;
using System.Text;

namespace Datester.Models
{
    using Data.Models;
    using Enums;

    public class UserOperations
    {
        public string UserOneId { get; set; }
        public ApplicationUser UserOne { get; set; }

        public string UserTwoId { get; set; }
        public ApplicationUser UserTwo { get; set; }

        public Operation Operation { get; set; }
    }
}
