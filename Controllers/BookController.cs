using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using systemBiblioteczny.Models;
using systemBiblioteczny.Models; 

namespace systemBiblioteczny.Controllers {

    public class BookController : Controller {

        private readonly BooksDbContext _context;

        public BookController(BooksDbContext context) { _context = context; }

        public ActionResult Index() { return View(_context.Books.Include(b => b.BookStatus).ToList()); }

        public ActionResult Details(int id) {
            ViewBag.IdBookStatus = new SelectList(_context.BooksStatuses.ToList(), "Id", "Status");
            return View(_context.Books.Find(id));
        }
        public ActionResult Create() {
            ViewBag.IdBookStatus = new SelectList(_context.BooksStatuses.ToList(), "Id", "Status");
            return View();
        }

        public ActionResult Reserve() {
            var rentals = _context.Rentals.Include(r => r.Book).Where(r => r.Status == "Pending").ToList();
            return View(rentals);
        }

        public ActionResult Borrowed() {
            var rentals = _context.Rentals.Include(r => r.Book).Where(r => r.Status == "Borrowed").ToList();
            return View(rentals);
        } 
        public ActionResult Archive() {
            var rentals = _context.Rentals.Include(r => r.Book).Where(r => r.Status == "Returned").ToList();
            return View(rentals);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Returned(int id, int idBook) {

            var book = _context.Books.Find(idBook);
            if (book == null) return RedirectToAction("Index");
            book.IdBookStatus = 1;

            var rental = _context.Rentals.Find(id);
            if (rental == null) return RedirectToAction("Borrowed");
            
            rental.Status = "Returned";
            rental.EndDate = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrowed(int id, int idBook) {
            var rental = _context.Rentals.Find(id);

            var book = _context.Books.Find(idBook);
            if (book == null) return RedirectToAction("Index");
            book.IdBookStatus = 3;

            if (rental == null) {
                var rentals = _context.Rentals.Include(r => r.Book).Where(r => r.Status == "Pending").ToList();
                return View(rentals);
            }

            rental.Status = "Borrowed";
            _context.SaveChanges();

            return RedirectToAction("Borrowed");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve(int id, int libraryCardNumber) {


            var book = _context.Books.Find(id);
            if (book == null) return RedirectToAction("Index");
            book.IdBookStatus = 2; // Reserved

            var rental = new Rental {
                IdBook = id,
                LibraryCardNumber = libraryCardNumber,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Status = "Pending"
            };

            _context.Rentals.Add(rental);
            _context.SaveChanges();
         
            return RedirectToAction("Reserve");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id", "Title", "Author", "Genre", "Description", "ReleaseDate", "IdBookStatus")] Book book) {

            if (ModelState.IsValid) {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            } 

            ViewBag.IdBookStatus = new SelectList(_context.BooksStatuses.ToList(), "Id", "Status");
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id", "Title", "Author", "Genre", "Description", "ReleaseDate", "IdBookStatus")] Book book) {
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book) {
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
