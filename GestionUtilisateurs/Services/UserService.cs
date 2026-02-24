using GestionUtilisateurs.Models;
using GestionUtilisateurs.Repositories;

namespace GestionUtilisateurs.Services
{
    public class UserService : IUserService
    {
        // Le service dépend du repository pour effectuer les opérations métier
        private readonly IUserRepository _userRepository;

        // Injection de dépendance via le constructeur
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Méthode pour créer un Utilisateur
        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);
        }

        // Méthode pour supprimer un Utilisateur
        public void DeleteUser(long id)
        {
            _userRepository.DeleteUser(id);
        }

        // Méthode pour lire tous les Utilisateurs
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        // Méthode pour lire un utilisateur grace à son Email
        public User? FindUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        // Méthode pour lire un utilisateur grace à son Id
        public User? FindUserById(long id)
        {
            return _userRepository.GetUserById(id);
        }

        // Méthode pour mettre à jour un utilisateur
        public void UpdateUser(User user)
        {
           _userRepository.UpdateUser(user);
        }
    }
}