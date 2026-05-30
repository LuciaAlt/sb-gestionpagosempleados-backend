using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SB.Entities.Base;
using SB.Models.Base;
using SB.Models.Contracts;
using SB.Repositories.Context;

namespace SB.Repositories.Implementation;

/// <summary>
/// Repositorio base genérico. Implementa CRUD común y la paginación avanzada
/// con la firma <see cref="GetPagedAsync"/> de la plantilla SIGASFL.
/// </summary>
public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class, IEntityBase
{
    protected readonly SBDbContext _context;

    protected RepositoryBase(SBDbContext context) => _context = context;

    public virtual Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        => _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, ct);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct = default)
        => await _context.Set<TEntity>().AsNoTracking().ToListAsync(ct);

    public virtual async Task AddAsync(TEntity entity, CancellationToken ct = default)
        => await _context.Set<TEntity>().AddAsync(entity, ct);

    public virtual void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

    public virtual void Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);

    public Task<int> SaveChangesAsync(CancellationToken ct = default) => _context.SaveChangesAsync(ct);

    /// <summary>
    /// Paginación avanzada — firma idéntica a la plantilla SIGASFL.
    /// Soporta predicate (filtro), include (navegaciones) y orderBy obligatorio.
    /// </summary>
    public virtual async Task<DataCollection<TEntity>> GetPagedAsync(
        int page,
        int take,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        CancellationToken ct = default)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        var originalPage = page;
        page--;
        if (page > 0)
            page = page * take;

        query = PrepareQuery(query, predicate, include, orderBy);

        var result = new DataCollection<TEntity>
        {
            Items = await query.Skip(page).Take(take).AsNoTracking().ToListAsync(ct),
            Total = await query.CountAsync(ct),
            Page = originalPage
        };
        if (result.Total > 0)
            result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));

        return result;
    }

    /// <summary>
    /// Compone un IQueryable aplicando include, predicate, orderBy y take en orden seguro.
    /// </summary>
    protected IQueryable<TEntity> PrepareQuery(
        IQueryable<TEntity> query,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int? take = null)
    {
        if (include != null)  query = include(query);
        if (predicate != null) query = query.Where(predicate);
        if (orderBy != null)  query = orderBy(query);
        if (take.HasValue)    query = query.Take(Convert.ToInt32(take));
        return query;
    }
}
