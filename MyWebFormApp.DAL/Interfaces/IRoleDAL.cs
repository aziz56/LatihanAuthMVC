using MyWebFormApp.BO;

namespace MyWebFormApp.DAL.Interfaces
{
    public interface IRoleDAL : ICrud<Role>
    {
        void AddUserToRole(string username, int roleId);
        void EditUserInRole(string username, int roleId);
    }
}
