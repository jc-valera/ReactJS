using Jcvalera.Core.Common.Entities;

namespace Jcvalera.Core.Common.Services
{
    public interface IUserBLL
    {
        Task SaveUser(User user);

        Task<User> GetUser(User user);

        Task<List<User>> GetAllUsers();

        Task UpdateUser(User user);

        Task DeleteUser(int idUser);

    }
}
