using System;
using System.Linq;
using Entity;
using kutuphane.Data.Abstract;

namespace kutuphane.Data.Concrete.EfCore
{
    public class EfUserRepository : IUserRepository
    {
        private LibraryContext context;
        public EfUserRepository(LibraryContext _context)
        {
            context = _context;
        }
        public void AddUser(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
           var user = context.Users.FirstOrDefault(i => i.UserId == userId);
           if (user != null)
           {
               context.Users.Remove(user);
                context.SaveChanges();
           }
        }

        public IQueryable<User> GetAll()
        {
           return context.Users;
        }

        public User GetById(int userId)
        {
           return context.Users.FirstOrDefault(i => i.UserId == userId);
        }

        public void SaveUser(User entity)
        {
            if (entity.UserId == 0)
            {
                context.Users.Add(entity);
            }
            else
            {
                var user = GetById(entity.UserId);
                if (user != null)
                {
                    user.Name=entity.Name;
                    user.SurName = entity.SurName;
                    user.BirthDate = DateTime.Now;
                    user.Gender = entity.Gender;
                }
            }
        }
    }
}