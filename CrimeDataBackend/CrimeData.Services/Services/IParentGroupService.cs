using CrimeData.Entities.Tables;

namespace CrimeData.Services.Services
{
    public interface IParentGroupService
    {
        Task<ParentGroup> InsertParentGroupAsync(ParentGroup parentGroup);
        Task<ParentGroup> GetParentGroupByIdAsync(int cityId);
        Task<ParentGroup> GetParentGroupByNameAsync(string name);
        Task<List<ParentGroup>> GetAllParentGroupsAsync();
    }
}
