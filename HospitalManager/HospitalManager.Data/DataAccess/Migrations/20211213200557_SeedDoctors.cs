using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManager.Data.DataAccess.Migrations
{
    public partial class SeedDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FirstName", "LastName", "PathToPhoto", "SpecializationId", "UserId" },
                values: new object[,]
                {
                    { 101, "Виктор", "Фёдоров", "01.jpg", 1, null },
                    { 128, "Инна", "Бабкова", "28.jpg", 3, null },
                    { 129, "Артём", "Калашников", "29.jpg", 4, null },
                    { 130, "Жанна", "Амосова", "30.jpg", 5, null },
                    { 131, "Эрик", "Борода", "31.jpg", 6, null },
                    { 132, "Светлана", "Телиман", "32.jpg", 7, null },
                    { 133, "Ян", "Гаврилов", "33.jpg", 8, null },
                    { 134, "Александра", "Точко", "34.jpg", 9, null },
                    { 135, "Александр", "Новиков", "35.jpg", 10, null },
                    { 136, "Анастасия", "Костенюкова", "36.jpg", 11, null },
                    { 137, "Эмир", "Тимерян", "37.jpg", 12, null },
                    { 127, "Арсен", "Кандыба", "27.jpg", 2, null },
                    { 138, "Наталья", "Вискунова", "38.jpg", 13, null },
                    { 140, "Яна", "Стивенко", "40.jpg", 15, null },
                    { 141, "Владислав", "Черников", "41.jpg", 16, null },
                    { 142, "Юлия", "Энова", "42.jpg", 17, null },
                    { 143, "Казимир", "Евпатов", "43.jpg", 18, null },
                    { 144, "Алла", "Малинова", "44.jpg", 19, null },
                    { 145, "Максим", "Яценко", "45.jpg", 20, null },
                    { 146, "Виктория", "Бабко", "46.jpg", 21, null },
                    { 147, "Дмитрий", "Ермоленко", "47.jpg", 22, null },
                    { 148, "Татьяна", "Смирнова", "48.png", 23, null },
                    { 149, "Станислав", "Актёров", "49.jpg", 6, null },
                    { 139, "Павел", "Ющенко", "39.jpg", 14, null },
                    { 150, "Элина", "Саенко", "50.jpg", 9, null },
                    { 126, "Арина", "Метсова", "26.jpg", 1, null },
                    { 124, "Ксения", "Алимова", "24.jpg", 6, null },
                    { 102, "Ольга", "Нифёдова", "02.jpg", 2, null },
                    { 103, "Игорь", "Кецман", "03.jpg", 3, null },
                    { 104, "Виктория", "Духова", "04.jpg", 4, null },
                    { 105, "Игорь", "Кедис", "05.jpg", 5, null },
                    { 106, "Катерина", "Ластова", "06.jpg", 2, null },
                    { 107, "Владислав", "Подоляк", "07.jpg", 7, null },
                    { 108, "Марина", "Травкина", "08.jpg", 8, null },
                    { 109, "Евгений", "Синсов", "09.jpg", 3, null },
                    { 110, "Виолетта", "Яценко", "10.jpg", 10, null },
                    { 111, "Сергей", "Приходько", "11.jpg", 11, null },
                    { 125, "Сергей", "Приходько", "25.jpg", 9, null },
                    { 112, "Любовь", "Брендёва", "12.jpg", 12, null },
                    { 114, "Юлия", "Вайина", "14.jpg", 14, null },
                    { 115, "Сергей", "Вратарь", "15.jpg", 15, null },
                    { 116, "Мирослава", "Ива", "16.jpg", 16, null }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FirstName", "LastName", "PathToPhoto", "SpecializationId", "UserId" },
                values: new object[,]
                {
                    { 117, "Иван", "Фоменко", "17.jpg", 17, null },
                    { 118, "Ника", "Енистова", "18.jpg", 18, null },
                    { 119, "Алексей", "Виноградов", "19.jpg", 19, null },
                    { 120, "Алёна", "Осипова", "20.jpg", 20, null },
                    { 121, "Ярослав", "Винник", "21.jpg", 21, null },
                    { 122, "Раиса", "Ридко", "22.jpg", 22, null },
                    { 123, "Евгений", "Анисимов", "23.jpg", 23, null },
                    { 113, "Тарас", "Можайский", "13.jpg", 13, null }
                });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Мужская и женская урология.Лечение проблем с потенцией. Консультация андролога.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Мужская и женская урология.Лечение проблем с потенцией.Консультация андролога.");
        }
    }
}
