using DevLibraryMads.Core.Entities;

namespace DevLibraryMads.Core.Repositories
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetAllAsync();
        public Task<Client> GetByIdAsync(int id);
        public Task AddAsync(Client client);
        public Task SaveChangesAsync();
        public Task UpdateAsync(Client client);
    }
}
