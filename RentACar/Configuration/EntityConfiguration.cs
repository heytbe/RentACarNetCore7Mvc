using Microsoft.EntityFrameworkCore;

namespace RentACar.Configuration
{
    public interface EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
    }
}
