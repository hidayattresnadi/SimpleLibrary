using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookService :IBookService
    {
        private static List<Book> Books = new List<Book>();
        public Book AddBook(Book inputBook)
        {
            var book = Books.Find( book => book.Id == inputBook.Id);
            if (book != null) 
            {
                return null;
            }
            Books.Add(inputBook);
            return inputBook;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }
        public Book GetBookById(int id)
        {
            Book chosenBook = Books.FirstOrDefault(foundBook => foundBook.Id == id);
            return chosenBook;
        }
        public Book UpdateBook(Book book, int id)
        {
            int indexBook = Books.FindIndex(filteredBook => filteredBook.Id == id);
            if (indexBook == -1)
            {
                return null;
            }
            var updatedBook = new Book
            {
                Id = id,
                Title = book.Title,
                Author = book.Author,
                PublicationYear = book.PublicationYear,
                ISBN = book.ISBN,
            };
            Books[indexBook] = updatedBook;
            return Books[indexBook];
        }
        public bool DeleteBook(int id)
        {
            int indexBook = Books.FindIndex(filteredBook => filteredBook.Id == id);
            if (indexBook == -1)
            {
                return false;
            }
            Books.RemoveAt(indexBook);
            return true;
        }
    }
}
