using usersAPI.Models;

namespace usersAPI.Services.Interfaces
{
    public interface IRole
    {
        //Como trabajamos de manera asincrona usamos el metodo task
        Task<List<UserRole>> GetList();
        Task<UserRole> Get(int idRole);
        Task<UserRole> Add(UserRole newRole);
        Task<bool> Update(UserRole updateRole);
        Task<bool> Delete(int idRole);
    }
}
