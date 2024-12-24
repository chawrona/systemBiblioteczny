using Microsoft.AspNetCore.Mvc;
using systemBiblioteczny.Models;

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
            return View(_context.Books.ToList());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Books.Find(id));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
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
