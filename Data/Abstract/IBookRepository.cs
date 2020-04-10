using System.Linq;
using Entity;

namespace kutuphane.Data.Abstract
{
    public interface IBookRepository
    {
        Book GetById(int bookId);
        IQueryable<Book> GetAll();
        void AddBook(Book entity);
        void DeleteBook(int bookId);
        void SaveBook(Book entity);
        void AddFav(Book entity);
        void RemoveFav(Book entity);

        void MarkRead(Book entity);
        void MarkUnread(Book entity);
    }
}