using AluraChallenge.Adopet.Domain.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraChallenge.Adopet.Data.Repositories
{
    public abstract class BaseRepository<T> : IDisposable where T : Entity 
    {
        protected T _entity;
        protected readonly AdopetDbContext _context;
        protected readonly IMediator _mediator;

        public BaseRepository(AdopetDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Método para salvar as alterações (efetuar commit) em banco de dados
        /// </summary>
        /// <returns><see cref="int"/></returns>
        public async Task<int> SaveAsync()
        {
            // Dispatch Domain Events collection.
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB. This makes
            // a single transaction including side effects from the domain event
            // handlers that are using the same DbContext with Scope lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB. This makes
            // multiple transactions. You will need to handle eventual consistency and
            // compensatory actions in case of failures.
            // fonte: https://learn.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/domain-events-design-implementation

            await DispatchDomainEventsAsync();

            return await _context.SaveChangesAsync();
        }

        protected async Task DispatchDomainEventsAsync()
        {
            var domainEventEntities = _context.ChangeTracker.Entries<Entity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents != null && po.DomainEvents.Any())
                .ToArray();

            foreach (var entity in domainEventEntities)
            {
                var events = entity.DomainEvents.ToArray();
                entity.DomainEvents.Clear();
                foreach (var entityDomainEvent in events)
                    await _mediator.Publish(entityDomainEvent);
            }
        }
    }
}
