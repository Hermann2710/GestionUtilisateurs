using GestionUtilisateurs.Models;

namespace GestionUtilisateurs.Services
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public User? GetUserById(long id);
        public User? GetUserByEmail(string email);
        public User CreateUser(User user);
        public User? UpdateUser(User user);
        public void DeleteUser(long id);
    }
}
