# SWTOR Optimizer

Une application pour optimiser son personnage sur Star Wars - The Old Republic

## Architecture

### SwtorOptimizer

Ce projet ASP .NET Core contient l'API pour les appels à la base de données et le front-end en Angular 8.

### SwtorOptimizer.Business

Ce projet .NET Standard contient les entités métier et les interfaces des services de la base de données.

### SwtorOptimizer.Database

Ce projet .NET Standard contient les implémentations des services de la base de données et d'accès aux entités métier.

### SwtorOptimizer.Calculator

Ce projet .NET Core (3.1) contient un service worker qui vérifie periodiquement les tâches de calcul en attente stockées dans la base de données.

## Docker

Le script docker-build.ps1 permet de construire les images Docker.

Le fichier docker-compose.yml est un exemple de fichier que vous pouvez utiliser si vous souhaitez héberger une instance de l'application chez vous.
