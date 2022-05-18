using Artistry.Core.Repositories;
using Artistry.Models;

namespace Artistry.Persistance.Repositories
{
    public class MembershipRepository : Repository<Membership>, IMembershipRepository
    {
        public MembershipRepository(ArtistryContext context) : base(context)
        {
        }
    }
}
