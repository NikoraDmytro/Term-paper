using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Medicine
    {
        [Key]
        [Required(ErrorMessage = "Medicine name is a required field!")]
        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? DosageForm { get; set; }

        [Required(ErrorMessage = "Unit of measure is a required field!")]
        [Column(TypeName = "varchar(20)")]
        public string? UnitOfMeasure { get; set; }

        [Required(ErrorMessage = "Medicine quantity is a required field!")]
        [Range(0, Int16.MaxValue, ErrorMessage = "Quantity of medicines in stock must be a logically justified number!")]
        public short QuantityInStock { get; set; }
    }
}