using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IBookService
    {
        Book AddBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book UpdateBook(Book book, int id);
        bool DeleteBook(int id);
    }
}
