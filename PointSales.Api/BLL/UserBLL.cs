using Jcvalera.Core.Common.Entities;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.BLL
{
    public class UserBLL : IUserBLL
    {
        public IUserDAL UserDAL;

        public UserBLL(IConfiguration configuration)
        {
            UserDAL = new UserDAL(configuration);
        }

        public async Task SaveUser(User user)
        {
            try
            {
                await UserDAL.SaveUser(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUser(User user)
        {
            try
            {
                var getUser = new User();

                getUser = await UserDAL.GetUser(user);

                return getUser;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var users = new List<User>();

                users = await UserDAL.GetAllUsers();

                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                await UserDAL.UpdateUser(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteUser(int idUser)
        {
            try
            {
                await UserDAL.DeleteUser(idUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
