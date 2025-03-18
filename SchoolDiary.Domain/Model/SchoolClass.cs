using System.ComponentModel.DataAnnotations;

namespace SchoolDiary.Domain.Model;

/// <summary>
/// Классы
/// </summary>
public class SchoolClass
{
    /// <summary>
    /// Идентификатор класса
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Номер класса
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Литера класса
    /// </summary>
    public string? Letter { get; set; } 
    
    /// <summary>
    /// Список учеников
    /// </summary>
    public virtual List<Student>? Students { get; set; } = [];
}

