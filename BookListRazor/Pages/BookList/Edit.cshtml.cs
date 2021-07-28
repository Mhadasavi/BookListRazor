using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);

        }
        //[HttpGet("{id}")]
        public async Task<IActionResult> OnPost([FromQuery]int id)
        {
            if (ModelState.IsValid)
            {
                var UpdateBook = await _db.Book.FindAsync(id);
                UpdateBook.Name = Book.Name;
                UpdateBook.Author = Book.Author;
                UpdateBook.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
