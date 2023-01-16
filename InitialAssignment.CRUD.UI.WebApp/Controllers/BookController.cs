using InitialAssignment.CRUD.BusinecLogic.Services.Contracts;
using InitialAssignment.CRUD.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InitialAssignment.CRUD.UI.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: BookController
        public async Task<IActionResult> Index(Book pBook = null)
        {
            if (pBook == null)
            {
                pBook = new Book();
            }
            if (pBook.Top_Aux == 0)
            {
                pBook.Top_Aux = 10;
            }
            else if (pBook.Top_Aux == -1)
            {
                pBook.Top_Aux = 0;
            }
            var books = await _bookService.FindAsync(pBook);
            ViewBag.Top = pBook.Top_Aux;
            return View(books);
        }

        // GET: BookController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(new Book { Id = id });
            return View(book);
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book pBook)
        {
            try
            {
                int result = await _bookService.CreateAsync(pBook);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pBook);
            }
        }

        // GET: BookController/Edit/5
        public async Task<IActionResult> Edit(Book pBook)
        {
            var book = await _bookService.GetByIdAsync(pBook);
            ViewBag.Error = "";
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book pBook)
        {
            try
            {
                int result = await _bookService.EditAsync(pBook);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pBook);
            }
        }

        // GET: BookController/Delete/5
        public async Task<IActionResult> Delete(Book pBook)
        {
            ViewBag.Error = "";
            var book = await _bookService.GetByIdAsync(pBook);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Book pBook)
        {
            try
            {
                int result = await _bookService.DeleteAsync(pBook);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pBook);
            }
        }
    }

}
