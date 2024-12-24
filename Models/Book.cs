using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace systemBiblioteczny.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Author { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Genre { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "int")]
        public int IdBookStatus { get; set; }

    }
}
