using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace systemBiblioteczny.Models
{
    public class BookStatus
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Status { get; set; }

        // Relacja
        public ICollection<Book> Books { get; set; }

    }
}

