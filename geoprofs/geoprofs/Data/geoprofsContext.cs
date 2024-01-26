using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using geoprofs.Models;
using Microsoft.EntityFrameworkCore;

namespace geoprofs.Data
{
    public class geoprofsContext : DbContext
    {
        public geoprofsContext (DbContextOptions<geoprofsContext> options)
            : base(options)
        {
        }
        public DbSet<Aanvraag>? Aanvraag { get; set; }
        public DbSet<geoprofs.Models.Aanvraag>? aanvragen { get; set; }
        public DbSet<geoprofs.Models.Werknemer>? Werknemer { get; set; }
        public DbSet<geoprofs.Models.Positie>? Positie { get; set; }
    }
}
