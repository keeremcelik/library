using System.Linq;
using Entity;

namespace kutuphane.Data.Abstract
{
    public interface IPublisherRepository
    {
        Publisher GetById(int publisherId);
        IQueryable<Publisher> GetAll();
        void AddPublisher(Publisher entity);
        void DeletePublisher(int publisherId);
        void SavePublisher(Publisher entity);
    }
}