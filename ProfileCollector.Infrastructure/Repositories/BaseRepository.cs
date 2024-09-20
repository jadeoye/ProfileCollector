using CSharpFunctionalExtensions;
using ProfileCollector.Application.Interfaces.Repositories;
using ProfileCollector.Domain.Interfaces;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Infrastructure.Repositories
{
    public class BaseRepository<T, TId> : IAsyncRepository<T, TId> where T : Entity<TId>, IAggregateRoot where TId : IComparable<TId>
    {
        protected readonly IAsyncDocumentSession _session;

        public BaseRepository(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public virtual async Task<T> AddAsync(T entity, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            if (entity == null) return entity;

            await _session.StoreAsync(entity, cancellationToken);
            
            if(saveChanges)
                await _session.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await _session.LoadAsync<T>(id, cancellationToken);

            return result;
        }
    }
}
