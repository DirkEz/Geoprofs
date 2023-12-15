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
    }
}
