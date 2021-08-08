using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CVApp.Data
{
    public class CVsDbContext : DbContext
    {
        public CVsDbContext(DbContextOptions<CVsDbContext> options) : base(options) { }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}
