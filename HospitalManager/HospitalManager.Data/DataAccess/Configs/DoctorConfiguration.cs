using HospitalManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.DataAccess.Configs
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(30);

            builder.HasOne(d => d.Specialization)
                .WithMany(mp => mp.Doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.User)
                .WithMany(u => u.Doctors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
