namespace Datester.Data.Models
{
    using Datester.Models.Enums;

    public class UserOperations
    {
        public string UserOneId { get; set; }
        public ApplicationUser UserOne { get; set; }

        public string UserTwoId { get; set; }
        public ApplicationUser UserTwo { get; set; }

        public Operation Operation { get; set; }
    }
}
