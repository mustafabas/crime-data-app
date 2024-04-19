using CrimeData.Entities.Tables;
using CrimeData.Services.Models;
using CrimeData.Services.Services.Models;
using CrimeData.Services.Services.Strategy;


namespace CrimeData.Services.Services
{
    public interface ICrimeService
    {
        CrimeResponse GetAllCrimes();
        Task<List<Crime>> InsertCrimes(List<InsertCrimeModel> seattleCrimes);
        Task<Crime> GetLatestCrimeDate();
    }
}
