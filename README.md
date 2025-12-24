# Procedural Dungeon Generator – Unity

## Description

Ce projet est un **outil de génération procédurale de donjons** développé en **C# avec Unity 6000.2.7f2**.  
Il ne s’agit pas d’un jeu finalisé, mais d’un **système technique autonome** visant à explorer et maîtriser les principes de génération procédurale, la structuration d’un projet Unity et la gestion algorithmique de niveaux.

Le générateur crée dynamiquement des donjons composés de salles interconnectées, avec des règles de placement, de probabilités et de reproductibilité via seed.

---

## Fonctionnalités principales

- Génération procédurale de donjons composés de salles reliées par des portes
- Détection de collisions sans moteur physique (Bounding Boxes / BoxCollider)
- Génération reproductible via système de **seed**
- Probabilités pondérées pour l’apparition des différents types de salles
- Gestion d’une **salle de départ** et d’une **salle de fin**
- Placement procédural d’ennemis et de pièces
- Interface utilisateur pour modifier les paramètres et régénérer le donjon en temps réel
- Caméra **free-fly** dédiée à l’exploration et au debug

---

## Architecture du projet

- **DungeonGenerator**  
  Orchestrateur principal de la génération (seed, taille, règles globales).

- **Room / RoomData**  
  Représentation logique des salles (type, connexions, probabilités).

- **RoomPlacer**  
  Placement spatial des salles et gestion des connexions via portes.

- **CollisionChecker**  
  Vérification des collisions entre salles à l’aide de Bounding Boxes.

- **ContentSpawner**  
  Placement procédural des ennemis et des pièces dans les salles valides.

- **UIController**  
  Gestion de l’interface utilisateur (paramètres, génération, seed).

- **FreeFlyCamera**  
  Caméra de navigation libre pour l’exploration et le debug.

---

## Technologies utilisées

- **Unity 6000.2.7f2**
- **C#**
- Génération procédurale
- Algorithmique spatiale
- UI Unity (Canvas)
- Debug visuel et outils internes

---

## Installation / Lancer le projet

1. Cloner le dépôt GitHub
2. Ouvrir le projet avec **Unity Hub**
3. Sélectionner la version **Unity 6000.2.7f2**
4. Ouvrir la scène principale
5. Lancer le projet depuis l’éditeur

---

## Utilisation / Contrôles

### Interface utilisateur
- Modification des paramètres de génération (seed, nombre de salles, probabilités)
- Bouton de régénération du donjon en temps réel

### Caméra free-fly
- Déplacement libre pour explorer le donjon généré
- Utilisée principalement pour le debug et l’analyse du layout

---

## Objectifs du projet

- Comprendre et implémenter un **système de génération procédurale**
- Structurer un projet Unity orienté outil technique
- Gérer des collisions sans dépendre du moteur physique
- Mettre en place des systèmes probabilistes contrôlés
- Développer des outils de debug et de paramétrage en temps réel

---

## Améliorations possibles

- Génération de layouts non orthogonaux
- Systèmes de contraintes avancées entre salles
- Sauvegarde / chargement de configurations
- Visualisation plus poussée des données de génération
- Intégration dans un projet de jeu complet

---

## Aperçu

*(Section dédiée à l’ajout de captures d’écran ou GIFs)*

---

## Auteur

Lucas  
Étudiant en BUT Informatique – Développement / Game Development  
Portfolio GitHub
