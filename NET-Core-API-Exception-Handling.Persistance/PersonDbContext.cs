using Microsoft.EntityFrameworkCore;
using NET_Core_API_Exception_Handling.Domain.Entities;
using NET_Core_API_Exception_Handling.Persistance.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Persistance
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.Entity<Person>().HasData
                (new Person { ID = 1, FirstName = "Ibra", LastName = "Jaber",
                EmailAddress = "jb@gmail.com", MartialStatus = Domain.HelperEnums.MartialStatus.Single });
        }


    }
}
