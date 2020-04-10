using System.Linq;
using Entity;
using kutuphane.Data.Abstract;

namespace kutuphane.Data.Concrete.EfCore
{
    public class EfAuthorRepository : IAuthorRepository
    {
        private LibraryContext context;
        public EfAuthorRepository(LibraryContext _context)
        {
            context= _context;
        }

        public void AddAuthor(Author entity)
        {
           context.Authors.Add(entity);
        }

        public void DeleteAuthor(int authorId)
        {
            var author = context.Authors.FirstOrDefault(i => i.Id == authorId);
            
            if (author != null )
            {
                context.Authors.Remove(author);
                context.SaveChanges();
            }
        }

        public IQueryable<Author> GetAll()
        {
            return context.Authors;
        }

        public Author GetById(int authorId)
        {
            return context.Authors.FirstOrDefault(i => i.Id == authorId);
        }

        public void SaveAuthor(Author entity)
        {
           if (entity.Id == 0)
           {
               context.Authors.Add(entity);
           }
           else
           {
               var author = GetById(entity.Id);
               if (author != null)
               {
                   author.Name = entity.Name;
                   author.Surname = entity.Surname;
                   author.isApproved = entity.isApproved;
               }
           }
           context.SaveChanges();
        }
    }
}