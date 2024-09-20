using CSharpFunctionalExtensions;
using ProfileCollector.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Application.Interfaces.Repositories
{
    public interface IAsyncRepository<T, TId> where T : Entity<TId>, IAggregateRoot where TId : IComparable<TId>
    {
        Task<T> AddAsync(T entity, bool saveChanges = false, CancellationToken cancellationToken = default);
    }
}
