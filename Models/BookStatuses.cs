using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace systemBiblioteczny.Models
{
    public class BookStatuses
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
