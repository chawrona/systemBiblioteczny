using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using systemBiblioteczny.Models;  // Zawiera klasy Book, BookStatus, Rental itp.

namespace systemBiblioteczny.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BooksStatuses { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Mo�esz dostosowa� tabel� u�ytkownik�w, np. doda� niestandardowe kolumny
            //builder.Entity<User>(entity =>
            //{
            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});



            // Je�li masz niestandardow� klas� User, dostosuj j� tutaj
            // builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
    }
}
