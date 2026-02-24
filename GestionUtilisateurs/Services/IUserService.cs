using GestionUtilisateurs.Models;

namespace GestionUtilisateurs.Services
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public User? FindUserById(long id);
        public User? FindUserByEmail(string email);
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(long id);
    }
}
