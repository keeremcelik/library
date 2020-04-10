using System.Linq;
using Entity;
using kutuphane.Data.Abstract;

namespace kutuphane.Data.Concrete.EfCore
{
    public class EfPublisherRepository : IPublisherRepository
    {
        private LibraryContext context;
        public EfPublisherRepository(LibraryContext _context)
        {
            context= _context;
        }

        public void AddPublisher(Publisher entity)
        {
            context.Publishers.Add(entity);
            context.SaveChanges();
        }

        public void DeletePublisher(int publisherId)
        {
            var publisher = context.Publishers.FirstOrDefault(i => i.PublisherId == publisherId);
            if (publisher != null)
            {
                context.Publishers.Remove(publisher);
                context.SaveChanges();
            }
        }

        public IQueryable<Publisher> GetAll()
        {
            return context.Publishers;
        }

        public Publisher GetById(int publisherId)
        {
           return context.Publishers.FirstOrDefault(i => i.PublisherId == publisherId);
        }

        public void SavePublisher(Publisher entity)
        {
           if (entity.PublisherId == 0)
           {
               context.Publishers.Add(entity);
           }
           else
           {
               var publisher = GetById(entity.PublisherId);
               if (publisher != null)
               {
                   publisher.Name = entity.Name;
               }
           }
           context.SaveChanges();
        }
    }
}