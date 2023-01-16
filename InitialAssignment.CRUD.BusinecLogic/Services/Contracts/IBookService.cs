using InitialAssignment.CRUD.Entities;

namespace InitialAssignment.CRUD.BusinecLogic.Services.Contracts
{
    public interface IBookService
    {
        Task<int> CreateAsync(Book pBook);
        Task<int> EditAsync(Book pBook);
        Task<int> DeleteAsync(Book pBook);
        Task<Book> GetByIdAsync(Book pBook);
        Task<List<Book>> GetAllAsync();
        Task<List<Book>> FindAsync(Book pBook);
    }
}
