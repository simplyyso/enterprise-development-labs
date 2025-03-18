using SchoolDiary.Domain.Services.InMemory;

namespace SchoolDiary.Domain.Tests;

public class StudentInMemoryRepositoryTests
{
    private readonly StudentInMemoryRepository _repository;

    public StudentInMemoryRepositoryTests()
    {
        // Инициализация репозитория с данными из DataSeeder
        _repository = new StudentInMemoryRepository();
    }

    /// <summary>
    /// Непараметрический тест метода, выводящего топ 5 студентов по среднему баллу
    /// </summary>
    [Fact]
    public async Task GetTop5StudentsByAverageGrade_ReturnsTop5StudentsOrderedByAverageGrade()
    {
        // Act
        var result = await _repository.GetTop5StudentsByAverageGrade();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count); // Всего 3 ученика в тестовых данных

        // Проверяем порядок (по убыванию среднего балла)
        Assert.Equal("Иванов Иван Иванович", result[0].FullName);
        Assert.Equal(5.0, result[0].AverageGrade);

        Assert.Equal("Сидоров Сидор Сидорович", result[1].FullName);
        Assert.Equal(3.5, result[1].AverageGrade);

        Assert.Equal("Петров Петр Петрович", result[2].FullName);
        Assert.Equal(3.0, result[2].AverageGrade);
    }

    /// <summary>
    /// Непараметрический тест метода, выводящего учеников в классе
    /// </summary>
    [Fact]
    public async Task GetStudentsByClassOrderedByFullName_ReturnsStudentsInSpecifiedClassOrderedByFullName()
    {
        // Arrange
        var classId = 1; // ID класса, который существует в DataSeeder

        // Act
        var result = await _repository.GetStudentsByClassOrderedByFullName(classId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count); // В классе с ID = 1 два ученика

        // Проверяем порядок (по ФИО)
        Assert.Equal("Иванов Иван Иванович", result[0].FullName);
        Assert.Equal("Петров Петр Петрович", result[1].FullName);
    }
}