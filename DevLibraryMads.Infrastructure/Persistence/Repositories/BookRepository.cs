using Dapper;
using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Enums;
using DevLibraryMads.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevLibraryMads.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly DevLibraryMadsDbContext _dbContext;
        private readonly string _ConnectionString;


        public BookRepository(DevLibraryMadsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _ConnectionString = configuration.GetConnectionString("DevLibraryMadsCs");
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

        public async Task UpdateAsync(Book book)
        {
            using (var sqlConnection = new SqlConnection(_ConnectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Books SET Title = @title, Description = @description, Author = @author WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { Title = book.Title, Description = book.Description, Author = book.Author, book.Id });

            }
        }
    }
}
