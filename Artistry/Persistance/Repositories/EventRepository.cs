using Artistry.Core.Repositories;
using Artistry.Models;
using Microsoft.EntityFrameworkCore;

namespace Artistry.Persistance.Repositories
{
    public class EventRepository : IEventRepository, IDisposable
    {
        private ArtistryContext _context;

        public EventRepository(ArtistryContext context)
        {
            this._context = context;
        }

        public void DeleteEvent(int id)
        {
            Event ev = _context.Events.Find(id);
            _context.Events.Remove(ev);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Event GetEvent(int id)
        {
            return _context.Events.Find(id);
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        public void InsertEvent(Event ev)
        {
            _context.Events.Add(ev);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEvent(Event ev)
        {
            _context.Entry(ev).State = EntityState.Modified;
        }
    }
}
