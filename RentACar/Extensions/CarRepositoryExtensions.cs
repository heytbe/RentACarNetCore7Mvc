using RentACar.Models;
using System.Collections.Generic;

namespace RentACar.Extensions
{
    public static class CarRepositoryExtensions
    {

        public static IEnumerable<Cars> SearchBrand(this IEnumerable<Cars> cars,string? searchBrand) 
        {
            if(searchBrand is not null)
            {
                return cars.Where(x => x.CarBrand.CarBrands.ToLower().Contains(searchBrand.ToLower()));
            }
            else
            {
                return cars;
            }
        }

        public static IEnumerable<Cars> FilterByPrice(this IEnumerable<Cars> query, int MinPrice, int MaxPrice, bool IsValidPrice)
        {
            if (IsValidPrice)
            {
                return query.Where(x => x.CarPrice >= MinPrice && x.CarPrice <= MaxPrice);
            }
            else
            {
                return query;
            }
        }

        public static IEnumerable<Cars> FilterByBrand(this IEnumerable<Cars> cars,int? carBrand)
        {
            if (carBrand is not null)
            {
                return cars.Where(x => x.Id.Equals(carBrand));
            }
            else
            {
                return cars;
            }
        }

        public static IEnumerable<Cars> FilterByModelDate(this IEnumerable<Cars> cars,string? carDate)
        {
            if(carDate is not null)
            {
                return cars.Where(x => x.CarDate.Equals(carDate));
            }
            else
            {
                return cars;
            }
        }
    }
}