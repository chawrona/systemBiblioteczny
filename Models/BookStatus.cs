using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace systemBiblioteczny.Models
{
    public class BookStatus
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}

