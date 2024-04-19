using CrimeData.Entities;
using CrimeData.Entities.Tables;

namespace CrimeData.Services.Services
{
    public interface ICrimeAgainstCategoryService
    {
        Task<CrimeAgainstCategory> InsertCrimeAgainstCategoryAsync(CrimeAgainstCategory crimeAgainsCategory);
        Task<CrimeAgainstCategory?> GetCrimeAgainstCategoryByIdAsync(int id);
        Task<List<CrimeAgainstCategory>> GetCrimeAgainstCategoriesAsync();
        Task<CrimeAgainstCategory?> GetCrimeAgainstCategoryByNameAsync(string name);

    }
}
