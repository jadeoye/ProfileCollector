using ProfileCollector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.Interfaces.Repositories
{
    public interface IUserRepository : IAsyncRepository<User, string>
    {
    }
}
