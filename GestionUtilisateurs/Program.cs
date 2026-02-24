using GestionUtilisateurs.Controllers;
using GestionUtilisateurs.Repositories;
using GestionUtilisateurs.Services;
using System;

namespace GestionUtilisateurs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialisation des couches (Injection de dépendances manuelle)
            IUserRepository repository = new UserRepository();
            IUserService userService = new UserService(repository);
            UserController controller = new UserController(userService);

            bool continuer = true;

            controller.AfficherTutoriel();

            while (continuer)
            {
                Console.WriteLine("\nChoisissez une option (1-5) ou 0 pour voir le tuto :");
                string choix = Console.ReadLine() ?? "";

                switch (choix)
                {
                    case "0":
                        controller.AfficherTutoriel();
                        break;
                    case "1":
                        controller.AfficherTousLesUtilisateurs();
                        break;
                    case "2":
                        controller.AjouterUtilisateur();
                        break;
                    case "3":
                        controller.ModifierUtilisateur();
                        break;
                    case "4":
                        controller.SupprimerUtilisateur();
                        break;
                    case "5":
                        continuer = false;
                        Console.WriteLine("Fermeture de l'application...");
                        break;
                    default:
                        Console.WriteLine("Option invalide.");
                        break;
                }
            }
        }
    }
}