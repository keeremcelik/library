using System.Collections.Generic;
using Entity;

namespace WebUI.Models
{
    public class BookModel
    {
        public List<Book> BookList {get;set;}
        public List<Author> AuthorList {get;set;}
        public List<Type> TypeList {get;set;}
        public List<Publisher> publisherList {get; set;}
        public List<Language> languageList {get; set;}
    }
}