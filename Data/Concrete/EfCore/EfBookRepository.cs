using System.Linq;
using Entity;
using kutuphane.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Collections.Generic;

namespace kutuphane.Data.Concrete.EfCore
{
    public class EfBookRepository : IBookRepository
    {
        private LibraryContext context;
        public EfBookRepository(LibraryContext _context)
        {
            context = _context;
        }
        public void AddBook(Book entity)
        {
            context.Books.Add(entity);
        }

        public void AddFav(Book entity)
        {
            var book = GetById(entity.BookId);

            if(book.isFavorite != true && book != null)
            {
                book.isFavorite = true;
                context.SaveChanges();
            }
          
        }

        public void DeleteBook(int bookId)
        {
           var book = context.Books.FirstOrDefault(i => i.BookId == bookId);
           if (book != null)
           {
               context.Books.Remove(book);
               context.SaveChanges();
           }
        }

        public IQueryable<Book> GetAll()
        {
            return context.Books;
        }
        
        public Book GetById(int bookId)
        {  
            return  context.Books.FirstOrDefault(i => i.BookId==bookId);
        }


        public void MarkRead(Book entity)
        {
            var book = GetById(entity.BookId);

            if(book.isReaded != true && book != null)
            {
                book.isReaded = true;
                context.SaveChanges();
            }
        }

        public void MarkUnread(Book entity)
        {
             var book = GetById(entity.BookId);

            if(book.isReaded != false && book != null)
            {
                book.isReaded = false;
                context.SaveChanges();
            }
        }

        public void RemoveFav(Book entity)
        {
          var book = GetById(entity.BookId);
          if (book != null && book.isFavorite!=false)
          {
              book.isFavorite=false;
              context.SaveChanges();
          }
        }

        public void SaveBook(Book entity)
        {
           if (entity.BookId==0)
           {
               context.Books.Add(entity);               
           }
           else
           {
               var book = GetById(entity.BookId);
               if (book != null)
               {
                   book.Name = entity.Name;
                   book.PageCount = entity.PageCount;
                   book.AuthorId = entity.AuthorId;
                   book.Image = entity.Image;
                   book.TypeId = entity.TypeId;
                   book.isApproved=entity.isApproved;
                   book.PublisherId=entity.PublisherId;
                   book.Abstract=entity.Abstract;
                   book.PublishDate=entity.PublishDate;
                   book.LanguageId=entity.LanguageId;
               }
           }
           context.SaveChanges();
        }
    }
}