using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolDiary.Domain.Data;
using SchoolDiary.Domain.Model;

namespace SchoolDiary.Domain.Services.InMemory
{
    /// <summary>
    /// Интерфейс репозитория для учеников
    /// </summary>
    public interface IStudentRepository
    {
        Task<Student> Add(Student entity);
        Task<bool> Delete(int key);
        Task<Student> Update(Student entity);
        Task<Student?> Get(int key);
        Task<IList<Student>> GetAll();
        Task<IList<(string FullName, double AverageGrade)>> GetTop5StudentsByAverageGrade();
    }
}

namespace SchoolDiary.Domain.Services.InMemory
{
    /// <summary>
    /// Имплементация репозитория для учеников, которая хранит коллекцию в оперативной памяти 
    /// </summary>
    public class StudentInMemoryRepository : IStudentRepository
    {
        private List<Student> _students;
        private List<Grade> _grades;

        /// <summary>
        /// Конструктор репозитория
        /// </summary>
        public StudentInMemoryRepository()
        {
            _students = DataSeeder.Students;
            _grades = DataSeeder.Grades;

            // Устанавливаем связь между учениками и их оценками
            foreach (var student in _students)
            {
                student.Grades = [];
                student.Grades.AddRange(_grades.Where(grade => grade.StudentID == student.Id));
            }
        }

        /// <inheritdoc/>
        public Task<Student> Add(Student entity)
        {
            try
            {
                _students.Add(entity);
            }
            catch
            {
                return null!;
            }
            return Task.FromResult(entity);
        }

        /// <inheritdoc/>
        public async Task<bool> Delete(int key)
        {
            try
            {
                var student = await Get(key);
                if (student != null)
                    _students.Remove(student);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <inheritdoc/>
        public async Task<Student> Update(Student entity)
        {
            try
            {
                await Delete(entity.Id);
                await Add(entity);
            }
            catch
            {
                return null!;
            }
            return entity;
        }

        /// <inheritdoc/>
        public Task<Student?> Get(int key) =>
            Task.FromResult(_students.FirstOrDefault(item => item.Id == key));

        /// <inheritdoc/>
        public Task<IList<Student>> GetAll() =>
            Task.FromResult((IList<Student>)_students);

        /// <inheritdoc/>
        public Task<IList<(string FullName, double AverageGrade)>> GetTop5StudentsByAverageGrade()
        {
            var topStudents = _students
                .Select(student => new
                {
                    FullName = student.FullName,
                    AverageGrade = _grades
                        .Where(grade => grade.StudentID == student.Id)
                        .Average(grade => grade.Value) // Вычисляем средний балл
                })
                .Where(x => x.AverageGrade > 0) // Исключаем учеников без оценок
                .OrderByDescending(x => x.AverageGrade) // Сортируем по убыванию среднего балла
                .Take(5) // Берем топ-5
                .Select(x => (x.FullName, x.AverageGrade)) // Преобразуем в кортеж
                .ToList();

            return Task.FromResult((IList<(string FullName, double AverageGrade)>)topStudents);
        }

        /// <inheritdoc/>
        public Task<IList<Student>> GetStudentsByClassOrderedByFullName(int classId)
        {
            var students = _students
                .Where(student => student.SchoolClassId == classId) // Фильтруем по ID класса
                .OrderBy(student => student.FullName) // Упорядочиваем по ФИО
                .ToList();

            return Task.FromResult((IList<Student>)students);
        }
    }
}
