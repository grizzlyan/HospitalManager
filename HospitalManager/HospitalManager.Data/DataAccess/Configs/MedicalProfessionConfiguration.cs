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

            builder.HasData(
                new MedicalProfession { Id = 1, ProfessionName = "Проктология" },
                new MedicalProfession { Id = 2, ProfessionName = "Урология" },
                new MedicalProfession { Id = 3, ProfessionName = "Гинекология" },
                new MedicalProfession { Id = 4, ProfessionName = "Дерматология" },
                new MedicalProfession { Id = 5, ProfessionName = "Гастроэнтерология" },
                new MedicalProfession { Id = 6, ProfessionName = "Эндокринология" },
                new MedicalProfession { Id = 7, ProfessionName = "Кардиология" },
                new MedicalProfession { Id = 8, ProfessionName = "Отоларингология" },
                new MedicalProfession { Id = 9, ProfessionName = "Неврология" },
                new MedicalProfession { Id = 10, ProfessionName = "Маммология" },
                new MedicalProfession { Id = 11, ProfessionName = "Хирургия" },
                new MedicalProfession { Id = 12, ProfessionName = "Флебология" },
                new MedicalProfession { Id = 13, ProfessionName = "Пульмонология" },
                new MedicalProfession { Id = 14, ProfessionName = "Аллергология" },
                new MedicalProfession { Id = 15, ProfessionName = "Травматология" },
                new MedicalProfession { Id = 16, ProfessionName = "Инфектология" },
                new MedicalProfession { Id = 17, ProfessionName = "Офтальмология" },
                new MedicalProfession { Id = 18, ProfessionName = "Нефрология" },
                new MedicalProfession { Id = 19, ProfessionName = "Гематология" },
                new MedicalProfession { Id = 20, ProfessionName = "Ревматология" },
                new MedicalProfession { Id = 21, ProfessionName = "Психотерапия" },
                new MedicalProfession { Id = 22, ProfessionName = "Пластическая хирургия" },
                new MedicalProfession { Id = 23, ProfessionName = "Нейрохирургия" });

            /*builder.HasData(
                new MedicalProfession { Id = 1, ProfessionName = "Proctology" },
                new MedicalProfession { Id = 2, ProfessionName = "Urology" },
                new MedicalProfession { Id = 3, ProfessionName = "Gynecology" },
                new MedicalProfession { Id = 4, ProfessionName = "Dermatology" },
                new MedicalProfession { Id = 5, ProfessionName = "Gastroenterology" },
                new MedicalProfession { Id = 6, ProfessionName = "Endocrinology" },
                new MedicalProfession { Id = 7, ProfessionName = "Cardiology" },
                new MedicalProfession { Id = 8, ProfessionName = "Otolaryngology" },
                new MedicalProfession { Id = 9, ProfessionName = "Neurology" },
                new MedicalProfession { Id = 10, ProfessionName = "Mammalogy" },
                new MedicalProfession { Id = 11, ProfessionName = "Surgery" },
                new MedicalProfession { Id = 12, ProfessionName = "Phlebology" },
                new MedicalProfession { Id = 13, ProfessionName = "Pulmonology" },
                new MedicalProfession { Id = 14, ProfessionName = "Allergology" },
                new MedicalProfession { Id = 15, ProfessionName = "Traumatology" },
                new MedicalProfession { Id = 16, ProfessionName = "Infectology" },
                new MedicalProfession { Id = 17, ProfessionName = "Ophthalmology" },
                new MedicalProfession { Id = 18, ProfessionName = "Nephrology" },
                new MedicalProfession { Id = 19, ProfessionName = "Hematology" },
                new MedicalProfession { Id = 20, ProfessionName = "Rheumatology" },
                new MedicalProfession { Id = 21, ProfessionName = "Psychotherapy" },
                new MedicalProfession { Id = 22, ProfessionName = "Plastic surgery" },
                new MedicalProfession { Id = 23, ProfessionName = "Neurosurgery" });*/
        }
    }
}
