using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistanse.IEntity.EntityContext
{
    public class TriangleContext : DbContext
    {
        public DbSet<Triangle> Triangles => Set<Triangle>();
        public TriangleContext(DbContextOptions<TriangleContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Triangles.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public TriangleContext() => Database.EnsureCreatedAsync();
    }
}

