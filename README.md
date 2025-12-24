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
  Classe centrale du système de génération.  
  Gère l’ensemble du processus : seed, nombre de salles, placement procédural, gestion des portes disponibles, génération de la salle de départ et de la salle de fin, ainsi que le spawn des ennemis et des pièces.  
  Assure également la détection des collisions entre salles à l’aide de Bounding Boxes (BoxCollider).

- **DataRoom**  
  Représente une salle individuelle du donjon.  
  Contient les données propres à chaque salle : positions des portes, positions possibles pour les ennemis et les pièces, BoxCollider servant de volume de collision, ainsi que la logique de spawn des entités.

- **RoomInstance**  
  Structure de données utilisée pour définir les prefabs de salles et leur probabilité d’apparition lors de la génération procédurale.

- **ManagerUI**  
  Gère l’interface utilisateur.  
  Permet de modifier dynamiquement les paramètres de génération (nombre de salles, ennemis, pièces, seed) et de régénérer le donjon après modification.

- **FreeFlyCamera**  
  Caméra de déplacement libre utilisée comme joueur.  
  Sert à l’exploration du donjon et au debug, avec contrôle de la rotation, de la vitesse et du déplacement en 3D.


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
