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
                new Specialization
                {
                    Id = 2,
                    SpecializationName = "Урология",
                    Description = "Мужская и женская урология.Лечение проблем с потенцией.Консультация андролога."
                },
                new Specialization
                {
                    Id = 3,
                    SpecializationName = "Гинекология",
                    Description = "Диагностика и лечение патологий шейки матки, воспалительных и невоспалительных заболеваний."
                },
                new Specialization
                {
                    Id = 4,
                    SpecializationName = "Дерматология",
                    Description = "Диагностика и лечение дерматологических заболеваний. Удаление кожных новообразований."
                },
                new Specialization
                {
                    Id = 5,
                    SpecializationName = "Гастроэнтерология",
                    Description = "Эффективное лечение заболеваний желудочно-кишечного тракта. Консультации по вопросам питания."
                },
                new Specialization
                {
                    Id = 6,
                    SpecializationName = "Эндокринология",
                    Description = "Диагностика и лечение заболеваний эндокринной системы: ожирения, сахарного диабета и щитовидной железы."
                },
                new Specialization
                {
                    Id = 7,
                    SpecializationName = "Кардиология",
                    Description = "Лечение заболеваний сердечно-сосудистой системы человека. Проведение ЭКГ, УЗИ сердца."
                },
                new Specialization
                {
                    Id = 8,
                    SpecializationName = "Отоларингология",
                    Description = "Диагностика и лечение заболеваний ЛОР-органов (уши, горло, нос). Удаление инородных предметов и серных пробок."
                },
                new Specialization
                {
                    Id = 9,
                    SpecializationName = "Неврология",
                    Description = "Диагностика и лечение заболеваний нервной системы человека. Лечение нарушений слуха, речи, памяти."
                },
                new Specialization
                {
                    Id = 10,
                    SpecializationName = "Маммология",
                    Description = "Диагностика и лечение заболеваний молочных желез. Пункция, УЗИ. Консультации маммолога-онколога."
                },
                new Specialization
                {
                    Id = 11,
                    SpecializationName = "Хирургия",
                    Description = "Удаление доброкачественных подкожных новообразований малоинвазивными методами. Консультации хирурга."
                },
                new Specialization
                {
                    Id = 12,
                    SpecializationName = "Флебология",
                    Description = "Диагностика и лечение заболеваний вен (атеросклероз, тромбоз, заболеваний аорты). Лечение варикоза."
                },
                new Specialization
                {
                    Id = 13,
                    SpecializationName = "Пульмонология",
                    Description = "Диагностика и лечение заболеваний органов дыхания (легкие, бронхи, трахеи). Лечение последствий курения."
                },
                new Specialization
                {
                    Id = 14,
                    SpecializationName = "Аллергология",
                    Description = "Диагностика, лечение и профилактика аллергии различного происхождения. Анализы на аллергены."
                },
                new Specialization
                {
                    Id = 15,
                    SpecializationName = "Травматология",
                    Description = "Лечение заболеваний опорно-двигательного аппарата. Укол-блокады, prp-терапия."
                },
                new Specialization
                {
                    Id = 16,
                    SpecializationName = "Инфектология",
                    Description = "Диагностика, лечение и профилактика инфекционных заболеваний."
                },
                new Specialization
                {
                    Id = 17,
                    SpecializationName = "Офтальмология",
                    Description = "Диагностика и лечение нарушений зрения у взрослых и детей. Подбор средств для зрения."
                },
                new Specialization
                {
                    Id = 18,
                    SpecializationName = "Нефрология",
                    Description = "Диагностика и лечение заболеваний почек: мочекаменная болезнь, пиелонефрит, хроническая болезнь почек."
                },
                new Specialization
                {
                    Id = 19,
                    SpecializationName = "Гематология",
                    Description = "Диагностика и лечение различных заболеваний крови и системы кроветворения."
                },
                new Specialization
                {
                    Id = 20,
                    SpecializationName = "Ревматология",
                    Description = "Лечение и профилактика заболеваний суставов и соединительной ткани."
                },
                new Specialization
                {
                    Id = 21,
                    SpecializationName = "Психотерапия",
                    Description = "Диагностика и лечение пациентов с острыми и тяжелыми психическими состояниями."
                },
                new Specialization
                {
                    Id = 22,
                    SpecializationName = "Пластическая хирургия",
                    Description = "Устранение косметических дефектов, а также деформаций тканей и органов."
                },
                new Specialization
                {
                    Id = 23,
                    SpecializationName = "Нейрохирургия",
                    Description = "Оперативное лечение заболеваний центральной и периферической нервной системы."
                });

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
