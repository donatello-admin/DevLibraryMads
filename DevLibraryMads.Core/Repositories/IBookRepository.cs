using DevLibraryMads.Core.Entities;

namespace DevLibraryMads.Core.Repositories
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllAsync();
        public Task<Book> GetByIdAsync(int id);
        public Task AddAsync(Book book);
        public Task SaveChangesAsync();
        public Task UpdateAsync(Book book);
    }
}
