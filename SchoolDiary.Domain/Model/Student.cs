using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDiary.Domain.Model
{
    public class Student
    {

        /// <summary>
        /// Идентификатор автора
        /// </summary>
        [Key]
        public required int Id { get; set; }

        /// <summary>
        /// Паспорт ученика
        /// </summary>
        public string? Passport { get; set; } // Паспортные данные

        /// <summary>
        /// ФИО ученика
        /// </summary>
        public string? FullName { get; set; } // ФИО ученика

        /// <summary>
        /// Дата рождения ученика
        /// </summary>
        public DateTime BirthDate { get; set; } // Дата рождения

        /// <summary>
        /// Список оценок
        /// </summary>
        public virtual List<Grade>? Grades { get; set; } = [];

        /// <summary>
        /// Id класса, в котором числится ученик
        /// </summary>
        public required int SchoolClassId { get; set; }

        public SchoolClass? SchoolClass { get; set; } // Класс ученика
    }
}
