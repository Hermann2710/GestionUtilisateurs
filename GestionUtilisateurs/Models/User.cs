namespace GestionUtilisateurs.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Identifiant: {Id} | Nom: {LastName} | Prénom: {FirstName} | Email: {Email} | Ajouté le: {CreatedAt} | Mis à jour le: {UpdatedAt}";
        }
    }
}
