namespace InitialAssignment.CRUD.DataAccess.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<int> CreateAsync(TEntity entity);
        Task<int> EditAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> FindAsync(TEntity entity);
    }
}
