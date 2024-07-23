            
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
           
            public DbSet<Dogadjaj> Dogadjaji { get; set; }
            public DbSet<Kafic> Kafici { get; set; }
            public DbSet<Komentar> Komentari { get; set; }
            public DbSet<Rezervacija> Rezervacije { get; set; }
            public DbSet<Sto> Stolovi { get; set; }
            public DbSet<KaficSlike> Slike {get; set;}
            
            
         
            public DbSet<Posetilac> PosetiociSaNalogom { get; set; }
            public DbSet<Radnik> Radnici { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder);
     
            
        }
    }
}