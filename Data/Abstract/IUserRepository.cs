using System.Linq;
using Entity;

namespace kutuphane.Data.Abstract
{
    public interface IUserRepository
    {
        User GetById(int userId);
        IQueryable<User> GetAll();
        void AddUser(User entity);
        void DeleteUser(int userId);
        void SaveUser(User entity);
    }
}