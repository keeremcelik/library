using System.Linq;
using Entity;
using kutuphane.Data.Abstract;

namespace kutuphane.Data.Concrete.EfCore
{
    public class EfTypeRepository : ITypeRepository
    {
        private LibraryContext context;
        public EfTypeRepository(LibraryContext _context)
        {
            context= _context;
        }

        public void AddType(Type entity)
        {
            context.Types.Add(entity);
            context.SaveChanges();
        }

        public void DeleteType(int typeId)
        {
           var type = context.Types.FirstOrDefault(i => i.TypeId == typeId);
           if (type !=null)
           {
               context.Types.Remove(type);
               context.SaveChanges();
           }
        }

        public IQueryable<Type> GetAll()
        {
           return context.Types;
        }

        public Type GetById(int typeId)
        {
           return context.Types.FirstOrDefault(i => i.TypeId == typeId);
        }

        public void SaveType(Type entity)
        {
            if (entity.TypeId == 0)
            {
                context.Types.Add(entity);
            }
            else
            {
                var type = GetById(entity.TypeId);
                if (type != null)
                {
                    type.Name = entity.Name;                    
                }
            }
            context.SaveChanges();
        }

      
    }
}