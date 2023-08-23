using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Models;

namespace RentACar.Configuration
{
    public class CarsConf : EntityConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.HasOne(x => x.CarType).WithMany(x => x.Cars).HasForeignKey(x => x.CarTypeId);
            builder.HasOne(x => x.CarBrand).WithMany(x => x.Cars).HasForeignKey(x => x.CarBrandId);
        }
    }
}
