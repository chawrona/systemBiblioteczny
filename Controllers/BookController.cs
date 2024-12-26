using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using systemBiblioteczny.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace systemBiblioteczny.Controllers
{
    public class BookController : Controller
    {

        private readonly BooksDbContext _context;

        public BookController(BooksDbContext context)
        {
            _context = context;
        }


        // GET: BookController
        public ActionResult Index()
        {
            //ViewData["error"] = "All good";

            //return View(_context.Books.ToList());
            return View(_context.Books.Include(b => b.BookStatus).ToList());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {

            var book = _context.Books.Find(id);
    
            ViewBag.IdBookStatus = new SelectList(_context.BooksStatuses.ToList(), "Id", "Status");

            return View(book);
        }

        // *****************************************
        // REZERWACJE KSIĄŻEK
        // *****************************************

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve(int id)
        {
            
             _context.Books.Find(id).IdBookStatus = 2;
             _context.SaveChanges();
                
            return RedirectToAction("Index");
        }

        // *****************************************
        // REZERWACJE KSIĄŻEK
        // *****************************************

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.IdBookStatus = new SelectList(_context.BooksStatuses.ToList(), "Id", "Status");
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id", "Title", "Author", "Genre", "Description", "ReleaseDate", "IdBookStatus")] Book book)
        {

            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            } else
            {
                ViewBag.IdBookStatus = new SelectList(_context.BooksStatuses.ToList(), "Id", "Status");
                return View(book);
            }


           
        }

        // GET: BookController/Edit/5

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id", "Title", "Author", "Genre", "Description", "ReleaseDate", "IdBookStatus")] Book book)
        {
            try
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                //ViewData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
