# 🌌 Stargate

Projet académique (SAÉ 2.4) réalisé en **C#** dans le cadre du BUT Informatique à l'IUT Robert Schuman.

Application de bureau Windows Forms permettant de gérer l'univers de Stargate : races, planètes, missions et membres du programme, à partir d'une base de données SQLite.

## ⚙️ Fonctionnalités

* Connexion avec mot de passe haché (BCrypt)
* Consultation des races et de leur fiche détaillée
* Consultation des planètes
* Création de missions
* Gestion des membres
* Statistiques
* Journal

## ▶️ Lancer le projet

Prérequis : **Windows**, **Visual Studio** récent avec le workload « Développement .NET Desktop » (.NET Framework 4.7.2).

1. Cloner le dépôt
2. Ouvrir `projetStarGate/projetStarGate.slnx` dans Visual Studio
3. Restaurer les packages NuGet (automatique à l'ouverture, sinon clic droit sur la solution puis « Restaurer les packages NuGet »)
4. Lancer le projet (F5)

La base de données `Stargate.db` et les images sont fournies dans `projetStarGate/bin/Debug/`.

## 🛠️ Technologies

* **C#** / **.NET Framework 4.7.2**
* **Windows Forms**
* **SQLite** (System.Data.SQLite)
* **BCrypt.Net** (hachage des mots de passe)
* **iTextSharp**
* **Git** (une branche par membre, fusion sur `main`)

## 📁 Structure

```text
projetStarGate/
├── *.cs / *.Designer.cs   # Formulaires et classes de l'application
├── Properties/            # Ressources et paramètres
└── bin/Debug/             # Base Stargate.db et images du jeu
```

## 👥 Équipe

Projet réalisé en **groupe de trois** :

* Mounir Chargui
* Erza Lushtaku
* Oleksii Dovbysh

Le travail a été réparti sur trois branches individuelles, fusionnées dans `main`.

Dépôt GitLab d'origine : https://git.unistra.fr/stargate2026/sae2.4_2026
