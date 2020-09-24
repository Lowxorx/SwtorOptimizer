# SWTOR Optimizer - Français

Une application pour optimiser son personnage sur Star Wars - The Old Republic

## Architecture

### SwtorOptimizer

Ce projet ASP .NET Core contient l'API pour les appels à la base de données et le front-end en Angular 10.

### SwtorOptimizer.Business

Ce projet .NET Standard contient les entités métier et les interfaces des services de la base de données.

### SwtorOptimizer.Database

Ce projet .NET Standard contient les implémentations des services de la base de données et d'accès aux entités métier.

### SwtorOptimizer.Calculator

Ce projet .NET Core (3.1) contient un service worker qui vérifie periodiquement les tâches de calcul en attente stockées dans la base de données.

## Docker

Le script docker-build.ps1 permet de construire les images Docker.

Le fichier docker-compose.yml est un exemple de fichier que vous pouvez utiliser si vous souhaitez héberger une instance de l'application chez vous.

Le fichier docker-compose-portainer.yml est un exemple de fichier que vous pouvez utiliser si vous souhaitez déployer l'application avec [Portainer](https://www.portainer.io/).

# SWTOR Optimizer - English

An application to optimize your character on Star Wars - The Old Republic

## Architecture

### SwtorOptimizer

This ASP .NET Core project contains the API for database calls and the Angular 10 frontend.

### SwtorOptimizer.Business

This .NET Standard project contains the business entities and interfaces of the database services.

### SwtorOptimizer.Database

This .NET Standard project contains the implementations of the database services and access to business entities.

### SwtorOptimizer.Calculator

This .NET Core project (3.1) contains a service worker that periodically checks the pending calculation tasks stored in the database.

## Docker

Use the docker-build.ps1 script to build Docker images.

The file docker-composes.yml is an example file that you can use if you want to host an instance of the application at home.

The file docker-compose-portainer.yml is an example file that you can use if you want to deploy the application with [Portainer](https://www.portainer.io/).
