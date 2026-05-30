using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using SB.Entities.Base;
using SB.Models.Base;

namespace SB.Models.Contracts;

/// <summary>
/// Contrato genérico de repositorio. Provee CRUD común + paginación avanzada
/// con soporte de predicados, includes y ordenamiento.
/// </summary>
public interface IRepositoryBase<TEntity> where TEntity : class, IEntityBase
{
    Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(TEntity entity, CancellationToken ct = default);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<int> SaveChangesAsync(CancellationToken ct = default);

    /// <summary>
    /// Paginación avanzada con predicate, include y orderBy.
    /// Devuelve DataCollection con Items, Total, Page y Pages.
    /// </summary>
    Task<DataCollection<TEntity>> GetPagedAsync(
        int page,
        int take,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        CancellationToken ct = default
    );
}
