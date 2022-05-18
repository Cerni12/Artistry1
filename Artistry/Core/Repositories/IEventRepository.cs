using Artistry.Models;

namespace Artistry.Core.Repositories
{
    public interface IEventRepository : IDisposable
    {
        IEnumerable<Event> GetEvents();
        Event GetEvent(int id);
        void InsertEvent(Event ev);
        void DeleteEvent(int id);
        void UpdateEvent(Event ev);
        void Save();
      
    }
}
