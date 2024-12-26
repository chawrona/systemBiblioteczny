namespace systemBiblioteczny.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int LibraryCardNumber { get; set; }

        public string Status { get; set; }


        public int IdBook { get; set; }
        public Book Book { get; set; }
    }
}
