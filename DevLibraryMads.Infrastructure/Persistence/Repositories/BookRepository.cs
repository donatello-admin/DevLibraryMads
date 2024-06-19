using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevLibraryMads.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly DevLibraryMadsDbContext _dbContext;

        public BookRepository(DevLibraryMadsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Book book)
        {
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var books = await _dbContext.Books.ToListAsync();

            return books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id);

            return book;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
