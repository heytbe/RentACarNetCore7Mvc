using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Models;

namespace RentACar.Configuration
{
    public class CarImageConf : EntityConfiguration<CarImages>
    {
        public void Configure(EntityTypeBuilder<CarImages> builder)
        {
            builder.HasOne(x => x.Cars).WithMany(x => x.CarImages).HasForeignKey(x => x.CarsId);
        }
    }
}
