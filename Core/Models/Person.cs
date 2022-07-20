using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public abstract class Person
    {
        [Required(ErrorMessage = "Name is a required field!")]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is a required field!")]
        [Column(TypeName = "varchar(50)")]
        public string? Surname { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Birth date is a required field!")]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public string FullName => Patronymic == String.Empty ?
            $"{Surname} {Name}" : 
            $"{Surname} {Name} {Patronymic}";
        
        [NotMapped]
        public int Age => DateTime.Today.Year - BirthDate.Year;
    }
}