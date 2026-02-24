using GestionUtilisateurs.Models;
using GestionUtilisateurs.Services;

namespace GestionUtilisateurs.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public void AfficherTutoriel()
        {
            Console.WriteLine("=== MENU GESTION UTILISATEURS ===");
            Console.WriteLine("1. Lister les utilisateurs");
            Console.WriteLine("2. Ajouter un utilisateur");
            Console.WriteLine("3. Modifier un utilisateur");
            Console.WriteLine("4. Supprimer un utilisateur");
            Console.WriteLine("5. Quitter");
            Console.WriteLine("=================================");
        }

        public void AfficherTousLesUtilisateurs()
        {
            var users = _userService.GetAllUsers();
            if (users.Count == 0)
            {
                Console.WriteLine("La liste est vide.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        public void AjouterUtilisateur()
        {
            Console.Write("Email : ");
            string email = Console.ReadLine() ?? "";

            if (_userService.GetUserByEmail(email) != null)
            {
                Console.WriteLine("Erreur : Cet email est déjà utilisé par un autre compte.");
                return;
            }

            Console.Write("Nom : ");
            string lastName = Console.ReadLine() ?? "";
            Console.Write("Prénom : ");
            string firstName = Console.ReadLine() ?? "";

            var newUser = new User { LastName = lastName, FirstName = firstName, Email = email };
            _userService.CreateUser(newUser);
            Console.WriteLine("Utilisateur créé avec succès.");
        }

        public void ModifierUtilisateur()
        {
            Console.Write("ID de l'utilisateur à modifier : ");
            if (long.TryParse(Console.ReadLine(), out long id))
            {
                var existingUser = _userService.GetUserById(id);
                if (existingUser == null)
                {
                    Console.WriteLine("Erreur : Aucun utilisateur trouvé avec cet ID.");
                    return;
                }

                Console.Write($"Nouvel email ({existingUser.Email}) [Entrée pour garder] : ");
                string newEmail = Console.ReadLine() ?? "";

                if (!string.IsNullOrEmpty(newEmail) && newEmail != existingUser.Email)
                {
                    if (_userService.GetUserByEmail(newEmail) != null)
                    {
                        Console.WriteLine("Erreur : Ce nouvel email est déjà pris.");
                        return;
                    }
                    existingUser.Email = newEmail;
                }

                Console.Write($"Nouveau nom ({existingUser.LastName}) : ");
                existingUser.LastName = Console.ReadLine() ?? existingUser.LastName;

                Console.Write($"Nouveau prénom ({existingUser.FirstName}) : ");
                existingUser.FirstName = Console.ReadLine() ?? existingUser.FirstName;

                _userService.UpdateUser(existingUser);
                Console.WriteLine("Modification réussie.");
            }
        }

        public void SupprimerUtilisateur()
        {
            Console.Write("ID de l'utilisateur à supprimer : ");
            if (long.TryParse(Console.ReadLine(), out long id))
            {
                var user = _userService.GetUserById(id);

                if (user != null)
                {
                    _userService.DeleteUser(id);
                    Console.WriteLine($"L'utilisateur {user.FirstName} {user.LastName} a été supprimé.");
                }
                else
                {
                    Console.WriteLine("Erreur : Impossible de supprimer, l'ID n'existe pas.");
                }
            }
        }
    }
}