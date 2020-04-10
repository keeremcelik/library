using System.Linq;
using Entity;
using kutuphane.Data.Abstract;

namespace kutuphane.Data.Concrete.EfCore
{
    public class EfLanguageRepository : ILanguageRepository
    {
        private LibraryContext context;
        public EfLanguageRepository(LibraryContext _context)
        {
            context= _context;
        }

        public void AddLanguage(Language entity)
        {
            context.Languages.Add(entity);
        }

        public void DeleteLanguage(int languageId)
        {
            var language = context.Languages.FirstOrDefault(i => i.LanguageId == languageId);
            if (language != null)
            {
                context.Languages.Remove(language);
                context.SaveChanges();
            }
        }

        public IQueryable<Language> GetAll()
        {
            return context.Languages;
        }

        public Language GetById(int languageId)
        {
            return context.Languages.FirstOrDefault(i => i.LanguageId == languageId);
        }

        public void SaveLanguage(Language entity)
        {
           if (entity.LanguageId == 0 )
           {
               context.Languages.Add(entity);
           }
           else
           {
               var language = GetById(entity.LanguageId);
               if (language != null)
               {
                   language.Code = entity.Code;
                   language.Name = entity.Name;
               }
           }
           context.SaveChanges();
        }
    }
}