using Artistry.Models;

namespace Artistry.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void InsertUser(User u);
        void DeleteUser(int id);
        void UpdateUser(User u);
        void Save();
    }
}
