using Datester.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Datester.Data
{
    public class DatesterDbContext : IdentityDbContext
    {
        public DatesterDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
    }
}