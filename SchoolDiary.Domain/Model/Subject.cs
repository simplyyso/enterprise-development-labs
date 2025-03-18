using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDiary.Domain.Model
{
    public class Subject
    {

        /// <summary>
        /// Идентификатор предмета
        /// </summary>
        [Key]
        public required int Id { get; set; }

        /// <summary>
        /// Название предмета
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Год обучения
        /// </summary>
        public int Year { get; set; }
    }
}
