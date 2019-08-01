namespace Datester.Data
{
    using Datester.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Models;

    public class DatesterDbContext : IdentityDbContext<ApplicationUser>
    {
        public DatesterDbContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<Date> Dates { get; set; }

        public DbSet<UsersDates> UsersDates{ get; set; }

        public DbSet<UsersPhotos> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsersDates>().HasKey(ud => new {ud.DateId, ud.UserId});
            builder.Entity<UserOperations>().HasKey(uo => new { uo.UserOneId, uo.UserTwoId});

            base.OnModelCreating(builder);
        }
    }
}