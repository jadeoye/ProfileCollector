using ProfileCollector.Domain.Entities;
using ProfileCollector.Infrastructure.Interfaces;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Infrastructure.Logging
{
    public class ExceptionLogger : IExceptionLogger
    {
        private readonly IDocumentStore _store;

        public ExceptionLogger(IDocumentStore store)
        {
            _store = store;
        }

        public async Task LogAsync(ExceptionLog log)
        {
            using (var session = _store.OpenAsyncSession())
            {
                await session.StoreAsync(log);
                await session.SaveChangesAsync();
            }
        }
    }
}
