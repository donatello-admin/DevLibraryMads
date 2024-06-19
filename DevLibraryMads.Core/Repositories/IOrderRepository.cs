using DevLibraryMads.Core.Entities;

namespace DevLibraryMads.Core.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllAsync();
        public Task<Order> GetByIdAsync(int id);
        public Task AddAsync(Order order);
        public Task SaveChangesAsync();
        public Task UpdateAsync(Order order);
    }
}
