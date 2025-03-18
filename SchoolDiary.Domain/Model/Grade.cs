using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDiary.Domain.Model
{
    public class Grade
    {
        /// <summary>
        /// Идентификатор оценки
        /// </summary>
        [Key]
        public required int Id { get; set; }

        // <summary>
        /// Id студента,связанного с оценками
        /// </summary>
        public required int StudentID { get; set; }

        /// <summary>
        /// Студент
        /// </summary>
        public Student? Student { get; set; }

        // <summary>
        /// Id предмета,связанного с оценками
        /// </summary>
        public required int SubjectID { get; set; }

        /// <summary>
        /// Предмет
        /// </summary>
        public Subject? Subject { get; set; } 

        /// <summary>
        /// Значение оценки
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Дата выставления оценки
        /// </summary>
        public DateTime Date { get; set; } // Дата выставления оценки
    }
}
