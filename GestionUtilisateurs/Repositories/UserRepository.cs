using GestionUtilisateurs.Models;

namespace GestionUtilisateurs.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Variable qui permettra de stocker les utilisateurs: C'est la simulation de la BD
        private readonly List<User> _users = new List<User>();

        // Création de l'utilisateur et génération d'un Id unique
        public User CreateUser(User user)
        {
            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            user.CreatedAt = DateTime.Now;

            _users.Add(user);
            return user;
        }

        // Suppression d'un utilisateur
        public void DeleteUser(long id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        // Lecture de tous les utilisateurs
        public List<User> GetAllUsers()
        {
            return _users.ToList();
        }

        // Lecture d'un utilisateur grace à son Email
        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        // Lecture d'un utilisateur grace à son Id
        public User? GetUserById(long id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        // Modification d'un utilisateur
        public User? UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.UpdatedAt = DateTime.Now;

                return existingUser;
            }

            return null;
        }
    }
}