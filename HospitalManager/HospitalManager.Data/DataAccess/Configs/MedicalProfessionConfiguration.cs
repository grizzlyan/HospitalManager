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
    public class MedicalProfessionConfiguration : IEntityTypeConfiguration<MedicalProfession>
    {
        public void Configure(EntityTypeBuilder<MedicalProfession> builder)
        {
            builder.Property(p => p.ProfessionName).IsRequired().HasMaxLength(50);
        }
    }
}
