using MyWebFormApp.BLL.DTOs;
using System.Collections.Generic;

namespace MyWebFormApp.BLL.Interfaces
{
    public interface IUserBLL
    {
        void ChangePassword(string username, string newPassword);
        void Delete(string username);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetRoleByUsername(string username, int RoleId );
        UserDTO GetByUsername(string username);
        void Insert(UserCreateDTO entity);
        UserDTO Login(string username, string password);
        UserDTO LoginMVC(LoginDTO loginDTO);

        UserDTO GetUserWithRoles(string username);
        IEnumerable<UserDTO> GetAllWithRoles();
    }
}
