# Gestion d'Utilisateurs - Application Console C#

Ce projet est une application console robuste permettant de gérer des utilisateurs en mémoire. Il a été conçu en respectant les principes de l'architecture en couches et l'injection de dépendances.

## 🏗️ Architecture du Projet

L'application suit une structure découpée pour favoriser la séparation des responsabilités (SOC) :

* **Models** : Définit l'entité `User`.
* **Repositories** : Gère l'accès aux données (actuellement une liste en mémoire `List<User>`).
* **Services** : Contient la logique métier (validation d'unicité, règles de gestion).
* **Controllers** : Orchestre les interactions entre l'utilisateur (Console) et la logique métier.



## 🚀 Fonctionnalités

Le système permet les opérations CRUD (Create, Read, Update, Delete) avec des règles de gestion strictes :

* **Affichage du tutoriel** : Guide l'utilisateur sur les commandes disponibles.
* **Liste des utilisateurs** : Affiche tous les utilisateurs via la méthode `ToString()`.
* **Ajout sécurisé** : 
    * Auto-incrémentation des identifiants (ID).
    * **Unicité de l'email** : Impossible d'ajouter un email déjà existant.
* **Modification contrôlée** :
    * Vérification de l'existence de l'utilisateur par ID.
    * Interdiction de changer l'email vers un email déjà utilisé par un tiers.
* **Suppression sécurisée** : Vérification préalable de l'existence de l'ID avant suppression.

## 🛠️ Technologies utilisées

* **.NET SDK** (C#)
* **LINQ** : Pour la manipulation efficace des collections.
* **Injection de dépendances** : Utilisation d'interfaces (`IUserRepository`, `IUserService`) pour assurer le découplage.

## 📋 Prérequis

* Installation du SDK .NET 6.0 ou supérieur.

## 🏃 Lancement de l'application

1.  Clonez le dépôt ou téléchargez les sources.
2.  Ouvrez un terminal dans le dossier racine du projet.
3.  Exécutez la commande suivante :
    ```bash
    dotnet run
    ```

## 📝 Exemple de code : Unicité de l'email

Le contrôle d'unicité est géré au niveau du controller avant l'appel au service :
```csharp
if (_userService.GetUserByEmail(email) != null)
{
    Console.WriteLine("Erreur : Cet email est déjà utilisé.");
    return;
}