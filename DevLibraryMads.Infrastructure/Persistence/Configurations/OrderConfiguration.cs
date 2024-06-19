using DevLibraryMads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLibraryMads.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(c => c.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.Id_Client);

            builder.HasOne(b => b.Book)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.Id_Book);
        }
    }
}
