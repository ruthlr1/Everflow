using Everflow.EventPlanner.Domain.Features.Events;
using Everflow.EventPlanner.Domain.Features.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Everflow.EventPlanner.Persistence.Database
{
    public class EverflowContext : DbContext
    {

        public EverflowContext(DbContextOptions<EverflowContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedPeople(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                Enum.GetValues(typeof(Role.RoleIndex))
                .Cast<Role.RoleIndex>()
                .Select(e => new Role()
                {
                    RoleId = (int)e,
                    RoleName = e.ToString(),
                })
            );
        }

        private void SeedPeople(ModelBuilder modelBuilder)
        {
            var person = new Person() { PersonId = -1, FirstName = "John", LastName = "Doe", EmailAddress = "john_blah@gmail.com",  };
            modelBuilder.Entity<Person>().HasData(person);

            PersonRole personRole = new PersonRole() { PersonId = -1, RoleId = (int)Role.RoleIndex.Admin };
            modelBuilder.Entity<PersonRole>().HasData(personRole);

        }
    }
}
