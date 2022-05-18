using Artistry.Core.Repositories;
using Artistry.Models;
using Microsoft.EntityFrameworkCore;

namespace Artistry.Persistance.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private ArtistryContext _context;
        public UserRepository(ArtistryContext context)
        {
            this._context = context;
        }

        public void DeleteUser(int id)
        {
            User u = _context.Users.Find(id);
            _context.Users.Remove(u);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void InsertUser(User u)
        {
            _context.Users.Add(u);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUser(User u)
        {
            _context.Entry(u).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
