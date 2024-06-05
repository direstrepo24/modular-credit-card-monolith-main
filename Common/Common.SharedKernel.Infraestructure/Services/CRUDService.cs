using System.Linq.Expressions;
using AutoMapper;
using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common.SharedKernel.Infraestructure;


public abstract class CRUDService<TQueryDTO, TRequestDTO, TKey, TEntity, TRepoAll, TContext>(IMapper mapper, TRepoAll repository, IUnitOfWork<TContext> unitOfWork) :
       ICRUDService<TQueryDTO, TRequestDTO, TKey, TEntity, TRepoAll, TContext>
       where TEntity : class, IEntityBase<TKey>
       where TRepoAll : IBaseRepository<TEntity, TContext>
       where TContext : DbContext, new()
{
    internal readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    internal readonly TRepoAll _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    internal readonly IUnitOfWork<TContext> _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    protected IMapper Mapper => _mapper;
    protected TRepoAll Repository => _repository;
    protected IUnitOfWork<TContext> UnitOfWork => _unitOfWork;

    public bool Exist(Expression<Func<TEntity, bool>> predicate) => _repository.Exist(predicate);

    public int Count(Expression<Func<TEntity, bool>> predicate) => _repository.GetCount(predicate);

    public async Task<TQueryDTO> FindByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        TEntity? getEntity = await _repository.GetByIdAsync(id, cancellationToken);
        if (getEntity != null)
            return Mapper.Map<TQueryDTO>(getEntity);
        else
            throw new GlobalCommonException(nameof(TEntity), CommonErrors.EntityNotFound(typeof(TEntity),id));
    }

    public async Task<TQueryDTO?> FindSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] include)
    {
        TEntity? getEntity = await _repository.FindSingleAsync(predicate, cancellationToken, include);
        if (getEntity != null)
            return Mapper.Map<TQueryDTO>(getEntity);
        else
            return default;
    }

    public async Task<IEnumerable<TQueryDTO>> AllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, string? orderBy = null, params string[] includes)
    {
        IEnumerable<TEntity> list = await _repository.AllAsync(predicate, cancellationToken, orderBy, includes);
        return Mapper.Map<IEnumerable<TQueryDTO>>(list);
    }

    public async Task<TQueryDTO> UpdateAsync(TRequestDTO objDTO, CancellationToken cancellationToken = default)
    {
        TEntity? updatedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);
        if (updatedEntity == null)
            throw new GlobalCommonException(nameof(TEntity), CommonErrors.EntityNotFound(typeof(TEntity),Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id)));
        Mapper.Map(objDTO, updatedEntity);
        _repository.Update(updatedEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Mapper.Map<TQueryDTO>(updatedEntity);
    }

    public async Task<TQueryDTO> UpdateAsync(Expression<Func<TEntity, bool>> keyPredicate, TRequestDTO objDTO, CancellationToken cancellationToken = default)
    {
        TEntity? updatedEntity = await _repository.FindSingleAsync(keyPredicate, cancellationToken);
        if (updatedEntity == null)
            throw new GlobalCommonException(nameof(TEntity), CommonErrors.EntityNotFound(typeof(TEntity)));
        Mapper.Map(objDTO, updatedEntity);
        _repository.Update(updatedEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Mapper.Map<TQueryDTO>(updatedEntity);
    }

    public async Task<TQueryDTO> InsertAsync(TRequestDTO objDTO, CancellationToken cancellationToken = default)
    {
        TEntity addEntity = Mapper.Map<TEntity>(objDTO);
        await _repository.AddAsync(addEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Mapper.Map<TQueryDTO>(addEntity);
    }
    public async Task<TQueryDTO> DeleteAsync(TRequestDTO objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
    {
        TEntity? deletedEntity = await _repository.GetByIdAsync(Convert.ToInt32(Mapper.Map<TEntity>(objDTO).Id), cancellationToken);
        if (deletedEntity == null)
            throw new GlobalCommonException(nameof(TEntity), CommonErrors.EntityNotFound(typeof(TEntity)));
        if (autoSave)
        {
            Mapper.Map(objDTO, deletedEntity);
            _repository.Update(deletedEntity);
        }
        else
            _repository.Delete(deletedEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Mapper.Map<TQueryDTO>(deletedEntity);
    }

    public async Task<TQueryDTO> DeleteAsync(Expression<Func<TEntity, bool>> keyPredicate, TRequestDTO? objDTO, bool autoSave = true, CancellationToken cancellationToken = default)
    {
        TEntity? deletedEntity = await _repository.FindSingleAsync(keyPredicate, cancellationToken);
        if (deletedEntity == null)
            throw new GlobalCommonException(nameof(TEntity), CommonErrors.EntityNotFound(typeof(TEntity)));
        if (autoSave && objDTO!=null)
        {
            Mapper.Map(objDTO, deletedEntity);
            _repository.Update(deletedEntity);
        }
        else
            _repository.Delete(deletedEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Mapper.Map<TQueryDTO>(deletedEntity);
    }
}