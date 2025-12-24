# 🧱 Procedural Dungeon Generator – Unity
## 📌 Description

Ce projet est un générateur procédural de donjons réalisé avec Unity et C#.
Il permet de générer dynamiquement un donjon composé de salles connectées par des portes, avec une gestion des collisions via des Bounding Boxes, un système de probabilités de salles, ainsi qu’une interface utilisateur interactive permettant de modifier les paramètres de génération en temps réel.

Le projet a été conçu comme un outil de génération plutôt qu’un jeu final.

## 🎮 Fonctionnalités principales
### 🏗️ Génération procédurale

Placement de salles à partir de portes disponibles

Vérification des collisions entre salles grâce aux Bounds (BoxCollider)

Génération contrôlée par un seed

Système de probabilité pondérée pour le choix des salles

Salle de départ et salle de fin

Réactivation automatique des murs sur les portes inutilisées

### 🎨 Visuel & structure

Couleurs différentes pour distinguer les types de salles

Sols et murs ajoutés pour une meilleure lisibilité du donjon

Visualisation des Bounding Boxes via OnDrawGizmosSelected

Hiérarchie propre avec parents dédiés (rooms, ennemis, pièces)

### 👾 Ennemis & objets

Placement aléatoire d’ennemis selon des positions prédéfinies

Placement de pièces (coins) dans les salles compatibles

Suppression des positions utilisées pour éviter les doublons

### 🖥️ Interface utilisateur (UI)

Une interface permet de modifier en temps réel :

Nombre de salles

Nombre d’ennemis

Nombre de pièces

Seed de génération

➡️ Un bouton permet de régénérer le donjon après chaque modification, sans relancer la scène.

### 🎥 Déplacement & caméra

Le “joueur” est une caméra en free-fly

Déplacement libre en 3D (ZQSD / WASD, espace, ctrl)

Rotation à la souris (clic droit)

Vitesse ajustable avec la molette

Curseur libre (mode outil / debug)

### 🧠 Architecture du projet
Scripts principaux
DungeonGenerator

Cœur du système de génération

Gestion du seed

Placement des salles

Vérification des collisions

Génération des ennemis et des pièces

Nettoyage et régénération du donjon

DataRoom

Données propres à chaque salle :

Portes

Positions d’ennemis

Positions de pièces

BoxCollider utilisé comme bounds

Spawn des ennemis et des pièces

Dessin des bounds avec Gizmos

RoomInstance

Structure de données contenant :

Le prefab de la salle

Sa probabilité d’apparition

ManagerUI

Gestion de l’interface utilisateur

Synchronisation sliders ↔ valeurs du générateur

Mise à jour du texte en temps réel

FreeFlyCamera

Déplacement libre de la caméra

Rotation à la souris

Contrôle de la vitesse de déplacement

## 🛠️ Technologies utilisées

Unity

C#

Input System

TextMeshPro

Gizmos (debug visuel)

Programmation orientée données

## 📷 Aperçu

(Tu peux ajouter ici des captures d’écran du donjon généré, des gizmos ou de l’UI)

## 🚀 Objectifs du projet

Comprendre et maîtriser la génération procédurale

Travailler la détection de collisions sans physique

Structurer un projet Unity de manière propre et lisible

Créer un outil modulaire et facilement extensible

## 📌 Améliorations possibles

Génération de couloirs

Rotation plus avancée des salles

Sauvegarde des seeds intéressants

Ajout de règles de génération (poids, distance, difficulté)

Intégration d’un vrai player

## 👤 Auteur

Lucas
Étudiant en informatique – BUT
Projet personnel Unity / Génération procédurale
