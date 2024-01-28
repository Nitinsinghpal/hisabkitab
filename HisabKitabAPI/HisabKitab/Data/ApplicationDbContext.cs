using HisabKitab.Models.Dairy;
using HisabKitab.Models.OnlineSelling;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HisabKitab.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<DairyPayments> DairyPayments { get; set; }
        public DbSet<VitaPayments> VitaPayments { get; set; }
        public DbSet<Investment> Investments { get; set; }


    }
}
