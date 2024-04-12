using CrimeData.Services.Models;


namespace CrimeData.Services.Services
{
    public interface ICrimeService
    {
        CrimeResponse GetAllCrimes();
    }
}
