using CrimeData.Data;
using CrimeData.Entities.Tables;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace CrimeData.Services.Services
{
    public class ParentGroupService : IParentGroupService
    {
        IAsyncRepository<ParentGroup> _parentGroupRepository;

        public ParentGroupService(IAsyncRepository<ParentGroup> parentGroupRepository)
        {
            _parentGroupRepository = parentGroupRepository;
        }

        public async Task<List<ParentGroup>> GetAllParentGroupsAsync()
        {
            var parentGroups = await _parentGroupRepository.ListAllAsync();
            return parentGroups.ToList();
        }

        public async Task<ParentGroup> GetParentGroupByIdAsync(int parentGroupId)
        {
            if (parentGroupId == 0) throw new Exception("ParentGroupId cannot bu null");
            var query = await _parentGroupRepository.GetByIdAsync(parentGroupId);
            return query;
        }

        public async Task<ParentGroup?> GetParentGroupByNameAsync(string name)
        {
            var query = await _parentGroupRepository.ListAllAsync();
            return query.FirstOrDefault(x => x.Name == name);
        }

        public async Task<ParentGroup> InsertParentGroupAsync(ParentGroup parentGroup)
        {
            if (parentGroup == null) throw new Exception("ParentGroup cannot bu null");

            return await _parentGroupRepository.AddAsync(parentGroup);
        }

    }
}
