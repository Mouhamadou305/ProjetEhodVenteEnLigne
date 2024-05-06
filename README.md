# Projet Ehod Vente en Ligne

**Liste des changements opérés :**
**Affichage des erreurs liés aux champs
**Internationalisation en Wolof
**Unit tests

Comment j'ai implémenté les erreurs dans différentes langues en utilisant les Annotations de données :

Tout d'abord, j'ai dû créer les différents fichiers de ressources pour chaque page. Les fichiers de ressources contiennent un dictionnaire où chaque clé est le nom du message d'erreur et sa valeur correspondante est le message d'erreur dans la langue appropriée. Certains fichiers de ressources existaient déjà mais pas pour la page de connexion. J'ai créé les fichiers manquants Login.en.rex et Login.fr.resx. Mais un problème est survenu. L'outil PublicResXFileCodeGenerator n'a pas pu générer les classes correspondant à ces fichiers de ressources. Cela était dû aux noms des fichiers de ressources. Par exemple, pour la page de connexion, un fichier Login.resx devait être créé afin qu'une classe Login soit générée à partir de ce fichier de ressources. Les fichiers Login.en.resx et Login.fr.resx ne génèrent pas de classes à partir d'eux mais sont liés à la classe Login générée à partir de Login.resx.
Deuxièmement, dans les View Models, nous utilisons des Annotations (Required, Pattern, ...) afin de spécifier les restrictions à appliquer aux attributs avec les messages d'erreur correspondants. Deux propriétés spéciales sont définies dans chaque annotation de données :
ErrorMessageResourceName : qui contient le nom du message d'erreur (il doit correspondre à une clé dans votre fichier de ressources)
ErrorMessageResourceType : qui contient le type de ressource contenant le message d'erreur (il doit être le nom de la classe générée à partir de votre fichier de ressources)
Troisièmement, nous devons ajouter le support des annotations de données de localisation dans la classe Program.cs :
services.AddDataAnnotationsLocalization();
Internationalisation en Wolof :

J'ai ajouté Login.wo.resx
J'ai ajouté Default.wo.resx
J'ai modifié Default.cshtml
J'ai modifié le Service de Langue
J'ai ajouté LanguageViewModel.wo.resx
Dans Order.cshtml, il fallait corriger des erreurs telles que :
Le contrôleur qui traitait la requête, l'affichage des messages d'erreurs
Il fallait aussi modifier OrderViewModel pour les annotations.

La même chose pour créer un produit sauf pour ce qui est du contrôleur.

Ce projet possède une base de données intégrée qui sera créée lorsque l’application sera exécutée pour la première fois. Pour la créer correctement, vous devez satisfaire aux prérequis ci-dessous et mettre à jour les chaînes de connexion pour qu’elles pointent vers le serveur MSSQL qui est exécuté sur votre PC en local.

**Prérequis** : MSSQL Developer 2019 ou Express 2019 doit être installé avec Microsoft SQL Server Management Studio (SSMS).

MSSQL : https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads

SSMS : https://docs.microsoft.com/fr-fr/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

*Remarque : les versions antérieures de MSSQL Server devraient fonctionner sans problèmes, mais elles n’ont pas été testées.

*Dans le projet P3AddNewFunctionalityDotNetCore, ouvrez le fichier appsettings.json.*

Vous avez la section ConnectionStrings qui définit les chaînes de connexion pour les 2 bases de données utilisées dans cette application.

      "ConnectionStrings":
      {
        "P3Referential": "Server=.;Database=P3Referential-2f561d3b-493f-46fd-83c9-6e2643e7bd0a;Trusted_Connection=True;MultipleActiveResultSets=true",
        "P3Identity": "Server=.;Database=Identity;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
  
**P3Referential** - chaîne de connexion à la base de données de l’application.

**P3Identity** - chaîne de connexion à la base de données des utilisateurs. Il s’agit d’une base de données indépendante, car une organisation utilise généralement plusieurs applications différentes. Au lieu
de laisser chaque application définir ses propres utilisateurs (et plusieurs identifiants et mots de passe différents pour un seul utilisateur), une organisation peut disposer d’une base de données utilisateur unique et utiliser des autorisations et des rôles pour définir les applications auxquelles l’utilisateur a accès. De cette façon, un utilisateur peut accéder à toutes les applications de l’organisation avec le même identifiant et le même mot de passe, mais il n’aura accès qu’aux bases de données et aux actions définies dans la base de données des utilisateurs.

Il existe des versions différentes de MSSQL (veuillez utiliser MSSQL pour ce projet et non une autre base de données). Lorsque vous configurez le serveur de base de données, diverses options modifient la configuration de sorte que les chaînes de connexion définies peuvent ne pas fonctionner.

Les chaînes de connexion définies dans le projet sont configurées pour MSSQL Server Standard 2019. L’installation n’a pas créé de nom d’instance, le serveur est donc simplement désigné par « . », qui désigne l’instance par défaut de MSSQL Server fonctionnant sur la machine actuelle. Pendant l’installation, c’est l’utilisateur intégré de Windows qui est configuré dans le serveur MSSQL par défaut.

Si vous avez installé MSSQL Express, la valeur à utiliser pour Server est très probablement .\SQLEXPRESS. Donc votre chaîne de connexion P3Referential serait :

    "P3Referential": "Server=.\SQLEXPRESS;Database=P3Referential-2f561d3b-493f-46fd-83c9-6e2643e7bd0a;Trusted_Connection=True;MultipleActiveResultSets=true"
  
Si vous avez des difficultés à vous connecter, essayez d’abord de vous connecter à l’aide de Microsoft SQL Server Management Studio (assurez-vous que le type d’authentification est « Authentification Windows »), ou consultez le site https://sqlserver-help.com/2011/06/19/help-whats-my-sql-server-name/.
Si le problème persiste, demandez de l’aide à votre mentor.
