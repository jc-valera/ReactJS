using Jcvalera.Core.Common.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.Common.Services
{
    public interface IUserDAL
    {
        Task SaveUser(User user);

        Task<User> GetUser(User user);

        Task<List<User>> GetAllUsers();

        Task UpdateUser(User user);

        Task DeleteUser(int idUser);
    }
}
