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
            builder.Property(p => p.SpecializationId).IsRequired();

            builder.HasOne(d => d.Specialization)
                .WithMany(mp => mp.Doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.User)
                .WithMany(u => u.Doctors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Doctor
                {
                    Id = 101,
                    FirstName = "Виктор",
                    LastName = "Фёдоров",
                    PathToPhoto = "01.jpg",
                    SpecializationId = 1
                },
                new Doctor
                {
                    Id = 102,
                    FirstName = "Ольга",
                    LastName = "Нифёдова",
                    PathToPhoto = "02.jpg",
                    SpecializationId = 2
                },
                new Doctor
                {
                    Id = 103,
                    FirstName = "Игорь",
                    LastName = "Кецман",
                    PathToPhoto = "03.jpg",
                    SpecializationId = 3
                },
                new Doctor
                {
                    Id = 104,
                    FirstName = "Виктория",
                    LastName = "Духова",
                    PathToPhoto = "04.jpg",
                    SpecializationId = 4
                },
                new Doctor
                {
                    Id = 105,
                    FirstName = "Игорь",
                    LastName = "Кедис",
                    PathToPhoto = "05.jpg",
                    SpecializationId = 5
                },
                new Doctor
                {
                    Id = 106,
                    FirstName = "Катерина",
                    LastName = "Ластова",
                    PathToPhoto = "06.jpg",
                    SpecializationId = 2
                },
                new Doctor
                {
                    Id = 107,
                    FirstName = "Владислав",
                    LastName = "Подоляк",
                    PathToPhoto = "07.jpg",
                    SpecializationId = 7
                },
                new Doctor
                {
                    Id = 108,
                    FirstName = "Марина",
                    LastName = "Травкина",
                    PathToPhoto = "08.jpg",
                    SpecializationId = 8
                },
                new Doctor
                {
                    Id = 109,
                    FirstName = "Евгений",
                    LastName = "Синсов",
                    PathToPhoto = "09.jpg",
                    SpecializationId = 3
                },
                new Doctor
                {
                    Id = 110,
                    FirstName = "Виолетта",
                    LastName = "Яценко",
                    PathToPhoto = "10.jpg",
                    SpecializationId = 10
                },
                new Doctor
                {
                    Id = 111,
                    FirstName = "Сергей",
                    LastName = "Приходько",
                    PathToPhoto = "11.jpg",
                    SpecializationId = 11
                },
                new Doctor
                {
                    Id = 112,
                    FirstName = "Любовь",
                    LastName = "Брендёва",
                    PathToPhoto = "12.jpg",
                    SpecializationId = 12
                },
                new Doctor
                {
                    Id = 113,
                    FirstName = "Тарас",
                    LastName = "Можайский",
                    PathToPhoto = "13.jpg",
                    SpecializationId = 13
                },
                new Doctor
                {
                    Id = 114,
                    FirstName = "Юлия",
                    LastName = "Вайина",
                    PathToPhoto = "14.jpg",
                    SpecializationId = 14
                },
                new Doctor
                {
                    Id = 115,
                    FirstName = "Сергей",
                    LastName = "Вратарь",
                    PathToPhoto = "15.jpg",
                    SpecializationId = 15
                },
                new Doctor
                {
                    Id = 116,
                    FirstName = "Мирослава",
                    LastName = "Ива",
                    PathToPhoto = "16.jpg",
                    SpecializationId = 16
                },
                new Doctor
                {
                    Id = 117,
                    FirstName = "Иван",
                    LastName = "Фоменко",
                    PathToPhoto = "17.jpg",
                    SpecializationId = 17
                },
                new Doctor
                {
                    Id = 118,
                    FirstName = "Ника",
                    LastName = "Енистова",
                    PathToPhoto = "18.jpg",
                    SpecializationId = 18
                },
                new Doctor
                {
                    Id = 119,
                    FirstName = "Алексей",
                    LastName = "Виноградов",
                    PathToPhoto = "19.jpg",
                    SpecializationId = 19
                },
                new Doctor
                {
                    Id = 120,
                    FirstName = "Алёна",
                    LastName = "Осипова",
                    PathToPhoto = "20.jpg",
                    SpecializationId = 20
                },
                new Doctor
                {
                    Id = 121,
                    FirstName = "Ярослав",
                    LastName = "Винник",
                    PathToPhoto = "21.jpg",
                    SpecializationId = 21
                },
                new Doctor
                {
                    Id = 122,
                    FirstName = "Раиса",
                    LastName = "Ридко",
                    PathToPhoto = "22.jpg",
                    SpecializationId = 22
                },
                new Doctor
                {
                    Id = 123,
                    FirstName = "Евгений",
                    LastName = "Анисимов",
                    PathToPhoto = "23.jpg",
                    SpecializationId = 23
                },
                new Doctor
                {
                    Id = 124,
                    FirstName = "Ксения",
                    LastName = "Алимова",
                    PathToPhoto = "24.jpg",
                    SpecializationId = 6
                },
                new Doctor
                {
                    Id = 125,
                    FirstName = "Сергей",
                    LastName = "Приходько",
                    PathToPhoto = "25.jpg",
                    SpecializationId = 9
                },
                new Doctor
                {
                    Id = 126,
                    FirstName = "Арина",
                    LastName = "Метсова",
                    PathToPhoto = "26.jpg",
                    SpecializationId = 1
                },
                new Doctor
                {
                    Id = 127,
                    FirstName = "Арсен",
                    LastName = "Кандыба",
                    PathToPhoto = "27.jpg",
                    SpecializationId = 2
                },
                new Doctor
                {
                    Id = 128,
                    FirstName = "Инна",
                    LastName = "Бабкова",
                    PathToPhoto = "28.jpg",
                    SpecializationId = 3
                },
                new Doctor
                {
                    Id = 129,
                    FirstName = "Артём",
                    LastName = "Калашников",
                    PathToPhoto = "29.jpg",
                    SpecializationId = 4
                },
                new Doctor
                {
                    Id = 130,
                    FirstName = "Жанна",
                    LastName = "Амосова",
                    PathToPhoto = "30.jpg",
                    SpecializationId = 5
                },
                new Doctor
                {
                    Id = 131,
                    FirstName = "Эрик",
                    LastName = "Борода",
                    PathToPhoto = "31.jpg",
                    SpecializationId = 6
                },
                new Doctor
                {
                    Id = 132,
                    FirstName = "Светлана",
                    LastName = "Телиман",
                    PathToPhoto = "32.jpg",
                    SpecializationId = 7
                },
                new Doctor
                {
                    Id = 133,
                    FirstName = "Ян",
                    LastName = "Гаврилов",
                    PathToPhoto = "33.jpg",
                    SpecializationId = 8
                },
                new Doctor
                {
                    Id = 134,
                    FirstName = "Александра",
                    LastName = "Точко",
                    PathToPhoto = "34.jpg",
                    SpecializationId = 9
                },
                new Doctor
                {
                    Id = 135,
                    FirstName = "Александр",
                    LastName = "Новиков",
                    PathToPhoto = "35.jpg",
                    SpecializationId = 10
                },
                new Doctor
                {
                    Id = 136,
                    FirstName = "Анастасия",
                    LastName = "Костенюкова",
                    PathToPhoto = "36.jpg",
                    SpecializationId = 11
                },
                new Doctor
                {
                    Id = 137,
                    FirstName = "Эмир",
                    LastName = "Тимерян",
                    PathToPhoto = "37.jpg",
                    SpecializationId = 12
                },
                new Doctor
                {
                    Id = 138,
                    FirstName = "Наталья",
                    LastName = "Вискунова",
                    PathToPhoto = "38.jpg",
                    SpecializationId = 13
                },
                new Doctor
                {
                    Id = 139,
                    FirstName = "Павел",
                    LastName = "Ющенко",
                    PathToPhoto = "39.jpg",
                    SpecializationId = 14
                },
                new Doctor
                {
                    Id = 140,
                    FirstName = "Яна",
                    LastName = "Стивенко",
                    PathToPhoto = "40.jpg",
                    SpecializationId = 15
                },
                new Doctor
                {
                    Id = 141,
                    FirstName = "Владислав",
                    LastName = "Черников",
                    PathToPhoto = "41.jpg",
                    SpecializationId = 16
                },
                new Doctor
                {
                    Id = 142,
                    FirstName = "Юлия",
                    LastName = "Энова",
                    PathToPhoto = "42.jpg",
                    SpecializationId = 17
                },
                new Doctor
                {
                    Id = 143,
                    FirstName = "Казимир",
                    LastName = "Евпатов",
                    PathToPhoto = "43.jpg",
                    SpecializationId = 18
                },
                new Doctor
                {
                    Id = 144,
                    FirstName = "Алла",
                    LastName = "Малинова",
                    PathToPhoto = "44.jpg",
                    SpecializationId = 19
                },
                new Doctor
                {
                    Id = 145,
                    FirstName = "Максим",
                    LastName = "Яценко",
                    PathToPhoto = "45.jpg",
                    SpecializationId = 20
                },
                new Doctor
                {
                    Id = 146,
                    FirstName = "Виктория",
                    LastName = "Бабко",
                    PathToPhoto = "46.jpg",
                    SpecializationId = 21
                },
                new Doctor
                {
                    Id = 147,
                    FirstName = "Дмитрий",
                    LastName = "Ермоленко",
                    PathToPhoto = "47.jpg",
                    SpecializationId = 22
                },
                new Doctor
                {
                    Id = 148,
                    FirstName = "Татьяна",
                    LastName = "Смирнова",
                    PathToPhoto = "48.png",
                    SpecializationId = 23
                },
                new Doctor
                {
                    Id = 149,
                    FirstName = "Станислав",
                    LastName = "Актёров",
                    PathToPhoto = "49.jpg",
                    SpecializationId = 6
                },
                new Doctor
                {
                    Id = 150,
                    FirstName = "Элина",
                    LastName = "Саенко",
                    PathToPhoto = "50.jpg",
                    SpecializationId = 9
                });
        }
    }
}
