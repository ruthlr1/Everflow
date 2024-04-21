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
        public DbSet<EventPerson> EventPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPeople(modelBuilder);
        }


        private void SeedPeople(ModelBuilder modelBuilder)
        {
            var person = new Person() { PersonId = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john_doe@gmail.com", Password = "johnDoe1"  };
            modelBuilder.Entity<Person>().HasData(person);
        }
    }
}
