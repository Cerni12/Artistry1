using Artistry.Core.Repositories;
using Artistry.Models;
using Microsoft.EntityFrameworkCore;

namespace Artistry.Persistance.Repositories
{
    public class ResourceRepository : IResourceRepository, IDisposable
    {

        private ArtistryContext _context;

        public ResourceRepository(ArtistryContext context)
        {
            this._context = context;
        }
        public void DeleteResource(int id)
        {
            Resource res = _context.Resources.Find(id);
            _context.Resources.Remove(res);
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

        public Resource GetResource(int id)
        {
            return _context.Resources.Find(id);
        }

        public IEnumerable<Resource> GetResources()
        {
            return _context.Resources.ToList();
        }

        public void InsertResource(Resource res)
        {
            _context.Resources.Add(res);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateResource(Resource res)
        {
            _context.Entry(res).State = EntityState.Modified;
        }
    }
}
