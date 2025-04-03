using InkRibbon.Shelf.Domain.Entities;

namespace InkRibbon.Shelf.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get(string idUser);
        Task BulkInsert(IEnumerable<User> user);
        Task Insert(User user);
        Task BulkUpdate(IEnumerable<User> user);
        Task Update(User user);
        Task Delete(string idUser);
    }
}
