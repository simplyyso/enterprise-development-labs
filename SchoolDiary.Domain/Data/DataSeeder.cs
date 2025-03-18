using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Data;

/// <summary>
/// Класс для заполнения коллекций данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Коллекция предметов, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<Subject> Subjects =
        [
                new Subject
                {
                    Id = 1,
                    Name = "Математика",
                    Year = 2023
                },
                new Subject
                {
                    Id = 2,
                    Name = "История",
                    Year = 2023
                },
                new Subject
                {
                    Id = 3,
                    Name = "Физика",
                    Year = 2022
                },
                new Subject
                {
                    Id = 4,
                    Name = "Химия",
                    Year = 2022
                },
                new Subject
                {
                    Id = 5,
                    Name = "Литература",
                    Year = 2023
                }
        ];

    /// <summary>
    /// Коллекция предметов, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<SchoolClass> SchoolClasses =
        [
            new SchoolClass
            {
                Id = 1,
                Number = 10,
                Letter = "A"
            },
            new SchoolClass
            {
                Id = 2,
                Number = 10,
                Letter = "Б"
            },
         ];

    /// <summary>
    /// Коллекция учеников, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<Student> Students =
        [
            new Student
            {
                Id = 1,
                Passport = "1234567890",
                FullName = "Иванов Иван Иванович",
                BirthDate = new DateTime(2005, 5, 15),
                SchoolClassId = 1,
            },
            new Student
            {
                Id = 2,
                Passport = "0987654321",
                FullName = "Петров Петр Петрович",
                BirthDate = new DateTime(2005, 8, 20),
                SchoolClassId = 1,
            },
            new Student
            {
                Id = 3,
                Passport = "1122334455",
                FullName = "Сидоров Сидор Сидорович",
                BirthDate = new DateTime(2004, 3, 10),
                SchoolClassId = 2,
            },
        ];

    /// <summary>
    /// Коллекция учеников, использующаяся для первичного наполнения базы данных (и инмемори репозиториев)
    /// </summary>
    public static readonly List<Grade> Grades =
        [
            new Grade
            {
                Id = 1,
                Value = 5,
                StudentID = 1,
                SubjectID = 1,
                Date = new DateTime(2023, 9, 1)
            },
            new Grade
            {
                Id = 2,
                Value = 4,
                StudentID = 3,
                SubjectID = 2,
                Date = new DateTime(2023, 9, 1)
            },
            new Grade
            {
                Id = 3,
                Value = 3,
                StudentID = 2,
                SubjectID = 3,
                Date = new DateTime(2023, 9, 1)
            },
            new Grade
            {
                Id = 4,
                Value = 5,
                StudentID = 1,
                SubjectID = 4,
                Date = new DateTime(2023, 9, 1)
            },
            new Grade
            {
                Id = 5,
                Value = 3,
                StudentID = 3,
                SubjectID = 5,
                Date = new DateTime(2023, 9, 1)
            },
        ];

}