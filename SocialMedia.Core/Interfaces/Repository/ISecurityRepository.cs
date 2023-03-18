using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces.Repository
{
    public interface ISecurityRepository : IGenericRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
