using InitialAssignment.CRUD.DataAccess.DataContext;
using InitialAssignment.CRUD.DataAccess.Repositories.Contracts;
using InitialAssignment.CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace InitialAssignment.CRUD.DataAccess.Repositories
{
    public class BookRepository : IGenericRepository<Book>
    {
        private readonly DBContext _dbContext;

        public BookRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Book pBook)
        {
            int result = 0;
            _dbContext.Add(pBook);
            result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> EditAsync(Book pBook)
        {
            int result = 0;
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == pBook.Id);
            book.Author = pBook.Author;
            book.Classification = pBook.Classification;
            book.Edition = pBook.Edition;
            book.Editorial = pBook.Editorial;
            book.Title = pBook.Title;
            book.Price = pBook.Price;
            book.PublicationDate = pBook.PublicationDate;
            _dbContext.Update(book);
            result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteAsync(Book pBook)
        {
            int result = 0;
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == pBook.Id);
            _dbContext.Remove(book);
            result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Book> GetByIdAsync(Book pBook)
        {
            var books = new Book();
            books = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == pBook.Id);
            return books;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var books = new List<Book>();
            books = await _dbContext.Books.ToListAsync();
            return books;
        }

        internal static IQueryable<Book> QuerySelect(IQueryable<Book> pQuery, Book pBook)
        {
            if (pBook.Id > 0)
            {
                pQuery = pQuery.Where(b => b.Id == pBook.Id);
            }
            if (!string.IsNullOrWhiteSpace(pBook.Author))
            {
                pQuery = pQuery.Where(b => b.Author.Contains(pBook.Author));
            }
            if (!string.IsNullOrWhiteSpace(pBook.Classification))
            {
                pQuery = pQuery.Where(b => b.Classification.Contains(pBook.Classification));
            }
            if (pBook.Edition > 0)
            {
                pQuery = pQuery.Where(b => b.Edition == pBook.Edition);
            }
            if (!string.IsNullOrWhiteSpace(pBook.Editorial))
            {
                pQuery = pQuery.Where(b => b.Editorial.Contains(pBook.Editorial));
            }
            if (!string.IsNullOrWhiteSpace(pBook.Title))
            {
                pQuery = pQuery.Where(b => b.Title.Contains(pBook.Title));
            }
            if (pBook.Price > 0)
            {
                pQuery = pQuery.Where(b => b.Price == pBook.Price);
            }
            if (pBook.PublicationDate.Year > 1000)
            {
                DateTime dateInitial = new DateTime(pBook.PublicationDate.Year, pBook.PublicationDate.Month, pBook.PublicationDate.Day, 0, 0, 0);
                DateTime finalDate = dateInitial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(b => b.PublicationDate >= dateInitial && b.PublicationDate <= finalDate);
            }
            pQuery = pQuery.OrderByDescending(b => b.Id).AsQueryable();
            if (pBook.Top_Aux > 0)
            {
                pQuery = pQuery.Take(pBook.Top_Aux).AsQueryable();
            }
            return pQuery;
        }

        public async Task<List<Book>> FindAsync(Book pBook)
        {
            var books = new List<Book>();
            var select = _dbContext.Books.AsQueryable();
            select = QuerySelect(select, pBook);
            books = await select.ToListAsync();
            return books;
        }

    }
}
