using Dapper;
using DevLibraryMads.Core.Entities;
using DevLibraryMads.Core.Enums;
using DevLibraryMads.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevLibraryMads.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly DevLibraryMadsDbContext _dbContext;
        private readonly string _ConnectionString;

        public OrderRepository(DevLibraryMadsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _ConnectionString = configuration.GetConnectionString("DevLibraryMadsCs");
        }

        public async Task AddAsync(Order order)
        {
            await _dbContext.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var orders = await _dbContext.Orders
                .Include(c => c.Client)
                .Include(b => b.Book)
                .ToListAsync();

            return orders;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _dbContext.Orders
                .Include(c => c.Client)
                .Include(b => b.Book)
                .SingleOrDefaultAsync(o => o.Id == id);

            return order;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            using (var sqlConnection = new SqlConnection(_ConnectionString))
            {
                sqlConnection.Open();

                var script = @"
                            UPDATE Orders 
                            SET 
                                Orders.StatusOrder = @statusOrder, 
                                Orders.ReturnedAt = @returnedAt, 
                                Orders.ValueFined = @valueFined
                            FROM Orders
                            WHERE Orders.NumPedVda = @numpedvda";

                await sqlConnection.ExecuteAsync(script, new
                {
                    statusOrder = StatusOrderEnum.Returned,
                    returnedAt = order.ReturnedAt,
                    valueFined = order.ValueFined,
                    numpedvda = order.NumPedVda
                });
            }
        }
    }
}
