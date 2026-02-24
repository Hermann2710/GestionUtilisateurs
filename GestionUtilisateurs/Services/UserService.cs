using GestionUtilisateurs.Models;
using GestionUtilisateurs.Repositories;

namespace GestionUtilisateurs.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public void DeleteUser(long id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User? GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User? GetUserById(long id)
        {
            return _userRepository.GetUserById(id);
        }

        public User? UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}