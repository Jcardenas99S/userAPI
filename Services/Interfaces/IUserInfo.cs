using usersAPI.Models;

namespace usersAPI.Services.Interfaces
{
    public interface IUserInfo
    {
        //Como trabajamos de manera asincrona usamos el metodo task
        Task<List<UserInfo>> GetList();
        Task<UserInfo> Get(int idUser);
        Task<UserInfo> Add(UserInfo newUser);
        Task<bool> Update(UserInfo updateUser);
        Task<bool> Delete(int idUser);
    }
}
