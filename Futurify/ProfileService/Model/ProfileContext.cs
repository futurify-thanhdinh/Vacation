using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProfileService.Model
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {
           
        }

        public ProfileContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public static void UpdateDatabase(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ProfileContext>();

            context.Database.MigrateAsync();

            ProfileContext.Seed(context);
        }

        private static void Seed(ProfileContext context)
        {
            //seed code
            Position position = new Position();
            position.PositionId = 1;
            position.PositionName = "Dev";
            context.Positions.Add(position);
            context.SaveChangesAsync();
        }
       
    }
}
