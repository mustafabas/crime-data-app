using CrimeData.Data;
using CrimeData.Entities;
using CrimeData.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CrimeData.Services.Services
{
    public class CrimeAgainstCategoryService : ICrimeAgainstCategoryService
    {
        private readonly IAsyncRepository<CrimeAgainstCategory> _crimeAgainstRepository;

        public CrimeAgainstCategoryService(IAsyncRepository<CrimeAgainstCategory> crimeAgainstCategoryRepo)
        {
            _crimeAgainstRepository = crimeAgainstCategoryRepo;
        }

        public  async Task<List<CrimeAgainstCategory>> GetCrimeAgainstCategoriesAsync()
        {
            var crimeAgainntCategories = await _crimeAgainstRepository.ListAllAsync();
            return crimeAgainntCategories.ToList();
        }

        public async Task<CrimeAgainstCategory?> GetCrimeAgainstCategoryByIdAsync(int id)
        {
            if (id == 0) throw new Exception("id cannot bu null");
            var query = await _crimeAgainstRepository.GetByIdAsync(id);
            return query;
        }

        public async Task<CrimeAgainstCategory?> GetCrimeAgainstCategoryByNameAsync(string name)
        {
            var query = _crimeAgainstRepository.Table;
            var crimeAgainstCategory = await query.FirstOrDefaultAsync(x => x.Name == name);
            return crimeAgainstCategory;
        }

        public async Task<CrimeAgainstCategory> InsertCrimeAgainstCategoryAsync(CrimeAgainstCategory crimeAgainsCategory)
        {
            if (crimeAgainsCategory == null) throw new Exception("crimeAgainsCategory cannot bu null");

            crimeAgainsCategory.CredatedAt = DateTime.Now;
            return await _crimeAgainstRepository.AddAsync(crimeAgainsCategory);
        }
    }
}
