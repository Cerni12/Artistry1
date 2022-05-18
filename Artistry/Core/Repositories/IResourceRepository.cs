using Artistry.Models;

namespace Artistry.Core.Repositories
{
    public interface IResourceRepository:IDisposable
    {
        IEnumerable<Resource> GetResources();
        Resource GetResource(int id);
        void InsertResource(Resource res);
        void DeleteResource(int id);
        void UpdateResource(Resource res);
        void Save();
       
    }
}
