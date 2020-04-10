using System.Linq;
using Entity;

namespace kutuphane.Data.Abstract
{
    public interface ILanguageRepository
    {
        Language GetById(int languageId);
        IQueryable<Language> GetAll();
        void AddLanguage(Language entity);
        void DeleteLanguage(int languageId);
        void SaveLanguage(Language entity);
    }
}