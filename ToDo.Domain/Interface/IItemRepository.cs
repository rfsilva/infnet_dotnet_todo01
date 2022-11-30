using ToDo.Domain.Entities;

namespace ToDo.Domain.Interface
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task AddAsync(Item item);
        Task EditAsync(Item item);
        Task <Item> getAsync(Guid Id);
        Task DeleteAsync(Guid Id);

    }
}
