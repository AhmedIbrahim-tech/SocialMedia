using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class SecurityRepository : GenericRepository<Security>, ISecurityRepository
    {
        private readonly SocialMediaContext _context;

        public SecurityRepository(SocialMediaContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _context.Set<Security>().FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}
