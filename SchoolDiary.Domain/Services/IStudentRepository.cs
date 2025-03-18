using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Services;
/// <summary>
/// Наследник обобщенного интерфейса для авторов с дополнительной функциональностью 
/// </summary>
public interface IStudentRepository : IRepository<Student, int>
{
    /// <summary>
    /// Вывести информацию обо всех учениках в указанном классе, упорядочить по ФИО.
    /// </summary>
    /// <param name = "classId" > ID класса</param>
    /// <returns>Список учеников, отсортированных по ФИО</returns>
    public Task<IList<Student>> GetStudentsByClassOrderedByFullName(int classId);

    /// <summary>
    /// Вывести информацию об 5 учеников по среднему баллу.
    /// </summary>
    Task<IList<(string FullName, double AverageGrade)>> GetTop5StudentsByAverageGrade();


}
