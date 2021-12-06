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
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.Property(p => p.SpecializationName).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Specialization
                { 
                    Id = 1, 
                    SpecializationName = "Проктология", 
                    Description = "Лечение геморроя и других проктологических заболеваний с помощью малоинвазивных методик."
                },
                new Specialization { Id = 2, SpecializationName = "Урология" },
                new Specialization { Id = 3, SpecializationName = "Гинекология" },
                new Specialization { Id = 4, SpecializationName = "Дерматология" },
                new Specialization { Id = 5, SpecializationName = "Гастроэнтерология" },
                new Specialization { Id = 6, SpecializationName = "Эндокринология" },
                new Specialization { Id = 7, SpecializationName = "Кардиология" },
                new Specialization { Id = 8, SpecializationName = "Отоларингология" },
                new Specialization { Id = 9, SpecializationName = "Неврология" },
                new Specialization { Id = 10, SpecializationName = "Маммология" },
                new Specialization { Id = 11, SpecializationName = "Хирургия" },
                new Specialization { Id = 12, SpecializationName = "Флебология" },
                new Specialization { Id = 13, SpecializationName = "Пульмонология" },
                new Specialization { Id = 14, SpecializationName = "Аллергология" },
                new Specialization { Id = 15, SpecializationName = "Травматология" },
                new Specialization { Id = 16, SpecializationName = "Инфектология" },
                new Specialization { Id = 17, SpecializationName = "Офтальмология" },
                new Specialization { Id = 18, SpecializationName = "Нефрология" },
                new Specialization { Id = 19, SpecializationName = "Гематология" },
                new Specialization { Id = 20, SpecializationName = "Ревматология" },
                new Specialization { Id = 21, SpecializationName = "Психотерапия" },
                new Specialization { Id = 22, SpecializationName = "Пластическая хирургия" },
                new Specialization { Id = 23, SpecializationName = "Нейрохирургия" });

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
