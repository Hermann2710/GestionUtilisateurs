using GestionUtilisateurs.Models;

namespace GestionUtilisateurs.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User? GetUserById(long id);
        public User? GetUserByEmail(string email);
        public User CreateUser(User user);
        public User? UpdateUser(User user);
        public void DeleteUser(long id);
    }
}
