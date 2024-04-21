using usersAPI.Models;

namespace usersAPI.Services.Interfaces
{
    public interface IUser
    {
        //Como trabajamos de manera asincrona usamos el metodo task
        Task<List<User>> GetList();
        Task<User> Get(int idUser);
        Task<User> Add(User newUser);
        Task<bool> Update(User updateUser);
        Task<bool> Delete(int idUser);
    }
}
