using MyWebFormApp.BO;
using System.Collections.Generic;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface IUserDAL : ICrud<User>
    {
        IEnumerable<User> GetAllWithRoles();
        User GetUserWithRoles(string username);
        User GetRoleByUsername(string username);
        User Login(string username, string password);
        void ChangePassword(string username, string newPassword);
        User GetByUsername(string username);

    }
}
