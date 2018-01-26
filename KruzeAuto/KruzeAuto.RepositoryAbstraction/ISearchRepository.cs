using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface ISearchRepository
    {
        List<Search> MainSearch(int VehicleType, string Condition, string Brand, string Model,
           int Kilometer, int FabricationYear, string FuelType1, string FuelType2, string FuelType3, string FuelType4,
           string FuelType5, string FuelType6, string FuelType7, int Price);
    }
}
