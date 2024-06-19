using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevLibraryMads.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DevLibraryMadsDbContext _dbContext;

        public ClientRepository(DevLibraryMadsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Client client)
        {
            await _dbContext.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            var clients = await _dbContext.Clients.ToListAsync();

            return clients;
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            var client = await _dbContext.Clients.SingleOrDefaultAsync(c => c.Id == id);

            return client;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
