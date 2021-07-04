using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EF
{
    public class BugsContext: DbContext
    {
        public BugsContext(DbContextOptions options):base(options)
        {

        }

        //DbContext represents database schema in the memory

        public DbSet<Core.Models.Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Use this to add relationships
            modelBuilder.Entity<Core.Models.Project>()
                .HasMany(p => p.Tickets)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);

            //seeding
            modelBuilder.Entity<Core.Models.Project>().HasData(
                new Core.Models.Project { ProjectId = 1, Name = "Project 1" },
                new Core.Models.Project { ProjectId = 2, Name = "Project 2" }
            );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, Title = "Bug #1", Description = "Bug #1 - Slow performance", ProjectId = 1 },
                new Ticket { TicketId = 2, Title = "Bug #2", Description = "Bug #2 - Internal Server Error", ProjectId = 1 },
                new Ticket { TicketId = 3, Title = "Bug #3", Description = "Bug #3 - Page not loading", ProjectId = 2 }
            );

            //base.OnModelCreating(modelBuilder);
        }
    }
}
