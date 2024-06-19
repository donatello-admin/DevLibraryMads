using Dapper;
using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevLibraryMads.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevLibraryMadsDbContext _dbContext;
        private readonly string _ConnectionString;

        public UserRepository(DevLibraryMadsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _ConnectionString = configuration.GetConnectionString("DevLibraryMadsCs");
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            return user;

        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string userName, string passwordHash)
        {
            return await _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.UserName == userName && u.Password == passwordHash);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetByUserNameAsync(string userName)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
                return userName;

            return user.UserName;
        }

        public async Task UpdateAsync(User user)
        {
            using (var sqlConnection = new SqlConnection(_ConnectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Users SET UserName = @username, Password = @password, Role = @role WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { UserName = user.UserName, Password = user.Password, Role = user.Role, user.Id });

            }
        }
    }
}
