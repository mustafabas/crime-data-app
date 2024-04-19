using CrimeData.Services.Services.Models;

namespace CrimeData.Services.Services.Strategy
{
    public interface IDataProcessStrategy<T>
    {
       Task<bool> FetchAndSaveData();
       List<InsertCrimeModel> Map(T response);
    }
}
