using DIASP.Abstract;
using DIASP.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DIASP.Pages
{
    public class BookModel : PageModel
    {
        private readonly IBookOutputService _bookOutputService;

        public Book Book { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public BookModel(IBookOutputService bookOutputService)
        {
            _bookOutputService = bookOutputService;
        }
        public void OnGet()
        {
            /*Book = new Book()
            {
                Name = "test",
                Author = "tes2t",
                Style = "test2",
                Age = 15,
            };

            _bookOutputService.SaveToFile(Book, "book.txt");*/

            Books = _bookOutputService.LoadBooks("book.txt");
        }
    }
}
