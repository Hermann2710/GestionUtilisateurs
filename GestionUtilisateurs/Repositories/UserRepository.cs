using GestionUtilisateurs.Models;

namespace GestionUtilisateurs.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public User CreateUser(User user)
        {
            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            user.CreatedAt = DateTime.Now;

            _users.Add(user);
            return user;
        }

        public void DeleteUser(long id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public List<User> GetAllUsers()
        {
            return _users.ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public User? GetUserById(long id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

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