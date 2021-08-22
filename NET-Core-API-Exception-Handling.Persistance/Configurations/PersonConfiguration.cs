using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET_Core_API_Exception_Handling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Persistance.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);

            builder.Property(p => p.EmailAddress).IsRequired();

            builder.Property(p => p.MartialStatus).IsRequired(false);

            builder.HasKey(p => p.ID);

        }
    }
}
