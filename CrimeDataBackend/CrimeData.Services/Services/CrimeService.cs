
using CrimeData.Services.Models;

namespace CrimeData.Services.Services
{
    public class CrimeService : ICrimeService
    {

        public CrimeService() { }

        public CrimeResponse GetAllCrimes()
        {
            var crimeData = new List<CrimeItemResponse>();
            crimeData.Add(new CrimeItemResponse("USA", "Theft", "PROPERTY", 122.21313f, 1.23131f));
            crimeData.Add(new CrimeItemResponse("USA", "Crisis", "PROPERTY", 122.21313f, 1.23131f));
            crimeData.Add(new CrimeItemResponse("USA", "abv", "PROPERTY", 122.21313f, 1.23131f));
            crimeData.Add(new CrimeItemResponse("USA", "asdad", "PROPERTY", 122.21313f, 1.23131f));
            var crimeResponse = new CrimeResponse(crimeData);
            return crimeResponse;
        }
    }
}
