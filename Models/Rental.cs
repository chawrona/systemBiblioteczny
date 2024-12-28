using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace systemBiblioteczny.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "int")]
        public int LibraryCardNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Status { get; set; }

        [ForeignKey("Book")]
        [Column(TypeName = "int")]
        public int IdBook { get; set; }

        public Book Book { get; set; }
    }
}