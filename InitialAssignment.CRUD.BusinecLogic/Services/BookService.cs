using InitialAssignment.CRUD.BusinecLogic.Services.Contracts;
using InitialAssignment.CRUD.DataAccess.Repositories.Contracts;
using InitialAssignment.CRUD.Entities;

namespace InitialAssignment.CRUD.BusinecLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _repository;

        public BookService(IGenericRepository<Book> repository)
        {
            _repository = repository;
        }
        public async Task<int> CreateAsync(Book pBook)
        {
            return await _repository.CreateAsync(pBook);
        }

        public async Task<int> EditAsync(Book pBook)
        {
            return await _repository.EditAsync(pBook);
        }
        public async Task<int> DeleteAsync(Book pBook)
        {
            return await _repository.DeleteAsync(pBook);
        }

        public async Task<Book> GetByIdAsync(Book pBook)
        {
            return await _repository.GetByIdAsync(pBook);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<Book>> FindAsync(Book pBook)
        {
            return await _repository.FindAsync(pBook);
        }

    }
}
