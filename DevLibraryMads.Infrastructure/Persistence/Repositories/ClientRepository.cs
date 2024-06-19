using Dapper;
using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevLibraryMads.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DevLibraryMadsDbContext _dbContext;
        private readonly string _ConnectionString;

        public ClientRepository(DevLibraryMadsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _ConnectionString = configuration.GetConnectionString("DevLibraryMadsCs");
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

        public async Task UpdateAsync(Client client)
        {
            using (var sqlConnection = new SqlConnection(_ConnectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Clients SET FullName = @fullname, BirdthDate = @birdthdate, Email = @email WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { FullName = client.FullName, BirdthDate = client.BirdthDate, Email = client.Email, client.Id });

            }
        }
    }
}
