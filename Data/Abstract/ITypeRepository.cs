using System.Linq;
using Entity;

namespace kutuphane.Data.Abstract
{
    public interface ITypeRepository
    {
        Type GetById(int typeId);
        IQueryable<Type> GetAll();
        void AddType(Type entity);
        void DeleteType(int typeId);
        void SaveType(Type entity);
    }
}