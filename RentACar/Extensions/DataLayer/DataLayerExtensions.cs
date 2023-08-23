using Microsoft.EntityFrameworkCore;
using RentACar.Context;
using RentACar.Shared;
using System.Reflection;

namespace RentACar.Extensions.DataLayer
{
    public static class DataLayerExtensions
    {
        public static void DataExtensions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration["ConnectionStrings:Mssql"]));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
