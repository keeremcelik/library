using System.Linq;
using Entity;

namespace kutuphane.Data.Abstract
{
    public interface IAuthorRepository
    {
        Author GetById(int authorId);
        IQueryable<Author> GetAll();
        void AddAuthor(Author entity);
        void DeleteAuthor(int authorId);
        void SaveAuthor(Author entity);
    }
}