using ProfileCollector.Application.Interfaces.Repositories;
using ProfileCollector.Domain.Entities;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository
    {
        public UserRepository(IAsyncDocumentSession session) : base(session) { }
    }
}
