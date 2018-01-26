using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System.Collections.Generic;


namespace KruzeAuto.Business
{
    public class SearchBusiness
    {

        public List<Search> MainSearch(int VehicleType, string Condition, string Brand, string Model,
           int Kilometer, int FabricationYear, string FuelType1, string FuelType2, string FuelType3, string FuelType4,
           string FuelType5, string FuelType6, string FuelType7, int Price)
        {
            return BusinessContext.Current.RepositoryContext.SearchRepository.MainSearch(VehicleType, Condition, Brand, Model,
          Kilometer, FabricationYear, FuelType1, FuelType2, FuelType3, FuelType4,
          FuelType5, FuelType6, FuelType7, Price);
        }
    }
}
