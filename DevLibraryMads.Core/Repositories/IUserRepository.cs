using DevLibraryMads.Core.Entities;

namespace DevLibraryMads.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string userName, string passwordHash);
        Task SaveChangesAsync();
        Task<string> GetByUserNameAsync(string userName);
        Task UpdateAsync(User user);

    }
}
