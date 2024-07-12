# Déployer une application .NET Aspire sur Azure Container Apps

Les applications .NET Aspire sont conçues pour s'exécuter dans des environnements conteneurisés. Azure Container Apps est un environnement entièrement géré qui vous permet d'exécuter des microservices et des applications conteneurisées sur une plateforme sans serveur. Cet article vous guidera dans la création d'une nouvelle solution .NET Aspire et son déploiement sur Microsoft Azure Container Apps à l'aide de Visual Studio et d'Azure Developer CLI (`azd`).

Dans cet exemple, nous supposerons que vous déployez l'application MyWeatherHub des sections précédentes. Vous pouvez utiliser le code que vous avez créé ou le code contenu dans le répertoire **complete**. Cependant, les étapes sont les mêmes pour n’importe quelle application .NET Aspire.

## Déployer l'application avec Visual Studio

1. Dans l'explorateur de solutions, cliquez avec le bouton droit sur le projet **AppHost** et sélectionnez **Publier** pour ouvrir la boîte de dialogue **Publier**.

 > [!TIP]
 > La publication .NET Aspire nécessite la version actuelle de la CLI `azd`. Celui-ci doit être installé avec le "workload" .NET Aspire, mais si vous recevez une notification indiquant que la CLI n'est pas installée ou à jour, vous pouvez suivre les instructions de la partie suivante de ce didacticiel pour l'installer.

1. Sélectionnez **Azure Container Apps for .NET Aspire** comme cible de publication.
 ![Une capture d'écran du flux de travail de la boîte de dialogue de publication.](./../../media/vs-deploy.png)
1. À l'étape **AzDev Environment**, sélectionnez les valeurs **Subscription** et **Location** souhaitées, puis entrez un **Environment name** tel que _aspire-weather_. Le nom de l’environnement détermine le nom des ressources de l’environnement Azure Container Apps.
1. Sélectionnez **Finish** pour créer l'environnement, puis **Close** pour quitter le workflow de boîte de dialogue et afficher le résumé de l'environnement de déploiement.
1. Sélectionnez **Publish** pour provisionner et déployer les ressources sur Azure.

 > [!TIP]
 > Ce processus peut prendre plusieurs minutes. Visual Studio fournit des mises à jour d'état sur la progression du déploiement dans les journaux de sortie et vous pouvez en apprendre beaucoup sur le fonctionnement de la publication en regardant ces mises à jour! Vous verrez que le processus implique la création d’un groupe de ressources, d’un Azure Container Registry, d’un espace de travail Log Analytics et d’un environnement Azure Container Apps. L’application est ensuite déployée dans l’environnement Azure Container Apps.

1. Une fois la publication terminée, Visual Studio affiche les URL des ressources en bas de l'écran de l'environnement. Utilisez ces liens pour afficher les différentes ressources déployées. Sélectionnez l'URL **webfrontend** pour ouvrir un navigateur sur l'application déployée.
    ![Une capture d'écran du processus de publication terminé et des ressources déployées.](./../../media/vs-publish-complete.png)

## Installer la CLI du développeur Azure

Le processus d'installation de `azd` varie en fonction de votre système d'exploitation, mais il est largement disponible via «winget», «brew», «apt» ou directement via «curl». Pour installer `azd`, consultez [Installer Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd).


### Initialiser le modèle

1. Ouvrez une nouvelle fenêtre de terminal et `cd` à la racine de votre projet .NET Aspire.
1. Exécutez la commande `azd init` pour initialiser votre projet avec `azd`, qui inspectera la structure des répertoires locaux et déterminera le type d'application.

    ```console
    azd init
    ```

    Pour plus d'informations sur la commande `azd init`, consultez [azd init](https://learn.microsoft.com/azure/developer/azure-developer-cli/reference#azd-init).
1. Si c'est la première fois que vous initialisez l'application, `azd` vous demande le nom de l'environnement :

    ```console
    Initializing an app to run on Azure (azd init)
    
    ? Enter a new environment name: [? for help]
    ```

    Entrez le nom de l'environnement souhaité pour continuer. Pour plus d'informations sur la gestion des environnements avec `azd`, consultez [azd env](https://learn.microsoft.com/azure/developer/azure-developer-cli/reference#azd-env).
1. Sélectionnez **Use code in the current directory** lorsque `azd` vous propose deux options d'initialisation de l'application.

    ```console
    ? How do you want to initialize your app?  [Use arrows to move, type to filter]
    > Use code in the current directory
      Select a template
    ```

1. Après avoir analysé le répertoire, `azd` vous invite à confirmer qu'il a trouvé le bon projet .NET Aspire _AppHost_. Sélectionnez l'option **Confirmer et continuer l'initialisation de mon application**.

    ```console
    Detected services:
    
      .NET (Aspire)
      Detected in: D:\source\repos\letslearn-dotnet-aspire\complete\AppHost\AppHost.csproj
    
    azd will generate the files necessary to host your app on Azure using Azure Container Apps.
    
    ? Select an option  [Use arrows to move, type to filter]
    > Confirm and continue initializing my app
      Cancel and exit
    ```

1. `azd` présente chacun des projets de la solution .NET Aspire et vous invite à identifier lesquels déployer avec une entrée HTTP ouverte publiquement à tout le trafic Internet. Sélectionnez uniquement `myweatherhub` (à l'aide des touches ↓ et Espace), car vous souhaitez que l'API soit privée pour l'environnement Azure Container Apps et _not_ disponible publiquement.

    ```console
    ? Select an option Confirm and continue initializing my app
    By default, a service can only be reached from inside the Azure Container Apps environment it is running in. Selecting a service here will also allow it to be reached from the Internet.
    ? Select which services to expose to the Internet  [Use arrows to move, space to select, <right> to all, <left> to none, type to filter]
      [ ]  apiservice
    > [x]  myweatherhub
    ```

1. Enfin, spécifiez le nom de l'environnement, qui est utilisé pour nommer les ressources provisionnées dans Azure et gérer différents environnements tels que `dev` et `prod`.

    ```console
    Generating files to run your app on Azure:
    
      (✓) Done: Generating ./azure.yaml
      (✓) Done: Generating ./next-steps.md
    
    SUCCESS: Your app is ready for the cloud!
    You can provision and deploy your app to Azure by running the azd up command in this directory. For more information on configuring your app, see ./next-steps.md
    ```

`azd` génère un certain nombre de fichiers et les place dans le répertoire de travail. Ces fichiers sont :

- _azure.yaml_ : décrit les services de l'application, tels que le projet .NET Aspire AppHost, et les mappe aux ressources Azure.
- _.azure/config.json_ : fichier de configuration qui informe `azd` quel est l'environnement actif actuel.
- _.azure/aspireazddev/.env_ : contient des remplacements spécifiques à l'environnement.
- _.azure/aspireazddev/config.json_ : fichier de configuration qui informe `azd` quels services doivent avoir un point de terminaison public dans cet environnement.

[](https://learn.microsoft.com/dotnet/aspire/deployment/azure/aca-deployment?tabs=visual-studio%2Cinstall-az-windows%2Cpowershell&pivots=azure-azd#deploy-the-app)

### Déployer l'application

Une fois `azd` initialisé, le processus de provisionnement et de déploiement peut être exécuté en tant que commande unique, [azd up](https://learn.microsoft.com/azure/developer/azure-developer-cli/reference#azd-up ).

```console

By default, a service can only be reached from inside the Azure Container Apps environment it is running in. Selecting a service here will also allow it to be reached from the Internet.
? Select which services to expose to the Internet webfrontend
? Select an Azure Subscription to use:  1. <YOUR SUBSCRIPTION>
? Select an Azure location to use: 1. <YOUR LOCATION>

Packaging services (azd package)


SUCCESS: Your application was packaged for Azure in less than a second.

Provisioning Azure resources (azd provision)
Provisioning Azure resources can take some time.

Subscription: <YOUR SUBSCRIPTION>
Location: <YOUR LOCATION>

  You can view detailed progress in the Azure Portal:
<LINK TO DEPLOYMENT>

  (✓) Done: Resource group: <YOUR RESOURCE GROUP>
  (✓) Done: Container Registry: <ID>
  (✓) Done: Log Analytics workspace: <ID>
  (✓) Done: Container Apps Environment: <ID>
  (✓) Done: Container App: <ID>

SUCCESS: Your application was provisioned in Azure in 1 minute 13 seconds.
You can view the resources created under the resource group <YOUR RESOURCE GROUP> in Azure Portal:
<LINK TO RESOURCE GROUP OVERVIEW>

Deploying services (azd deploy)

  (✓) Done: Deploying service apiservice
  - Endpoint: <YOUR UNIQUE apiservice APP>.azurecontainerapps.io/

  (✓) Done: Deploying service webfrontend
  - Endpoint: <YOUR UNIQUE webfrontend APP>.azurecontainerapps.io/


SUCCESS: Your application was deployed to Azure in 1 minute 39 seconds.
You can view the resources created under the resource group <YOUR RESOURCE GROUP> in Azure Portal:
<LINK TO RESOURCE GROUP OVERVIEW>

SUCCESS: Your up workflow to provision and deploy to Azure completed in 3 minutes 50 seconds.
```

Tout d'abord, les projets seront regroupés dans des conteneurs pendant la phase `package azd`, suivie de la phase `azd provision` au cours de laquelle toutes les ressources Azure dont l'application aura besoin sont provisionnées.

Une fois le `provision` terminé, le `azd deploy` aura lieu. Au cours de cette phase, les projets sont poussés en tant que conteneurs dans une instance Azure Container Registry, puis utilisés pour créer de nouvelles révisions d'Azure Container Apps dans lesquelles le code sera hébergé.

À ce stade, l’application a été déployée et configurée, et vous pouvez ouvrir le portail Azure et explorer les ressources.

## Nettoyer les ressources

Exécutez la commande Azure CLI suivante pour supprimer le groupe de ressources lorsque vous n’avez plus besoin des ressources Azure que vous avez créées. La suppression du groupe de ressources supprime également les ressources qu'il contient.

```console
az group delete --name <votre-nom-de-groupe-de-ressources>
```