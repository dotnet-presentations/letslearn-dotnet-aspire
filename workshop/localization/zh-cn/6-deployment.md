# 将 .NET Aspire 应用部署为 Azure Container Apps

.NET Aspire 针对注定要在容器化环境中运行的应用程序进行了优化。[Azure Container Apps](https://learn.microsoft.com/azure/container-apps/overview) 是一个完全托管的环境，使您能够在无服务器平台上运行微服务和容器化应用程序。本文将指导你创建新的 .NET Aspire 解决方案，并使用 Visual Studio 和 Azure 开发人员 CLI （`azd`） 将其部署为 Microsoft Azure 容器应用。

在此示例中，我们假设您正在部署前面部分中的 MyWeatherHub 应用程序。您可以使用已生成的代码，也可以使用 **complete** 目录中的代码。但是，对于任何 .NET Aspire 应用程序，一般步骤都是相同的。

## 使用 Visual Studio 部署应用

1. 在解决方案管理器上，在 **AppHost** 项目上右键，然后在弹出菜单上选择  **Publish** 来打开  **Publish** 对话框。

  > [!TIP]
  > 发布 .NET Aspire 需要最新版本的 `azd` CLI。这应该与 .NET Aspire 工作负载一起安装，但如果您收到 CLI 未安装或未更新的通知，则可以按照本教程下一部分中的说明进行安装。

1. 选择 **Azure Container Apps for .NET Aspire** 作为发布目标。

    ![A screenshot of the publishing dialog workflow.](media/vs-deploy.png)

2. 在 **AzDev Environment** 步骤中，选择所需的 **Subscription** 和 **Location**  值，然后输入 **Environment name** ，例如 _aspire-weather_。 环境名称决定了 Azure 容器应用环境资源的命名。
3. 选择 **Finish** 来创建环境，然后点击 **Close** 来关闭对话框并查看部署的环境汇总。
4. 选择 **Publish** 在 Azure 上预配和部署资源

    > [!TIP]
    > 此过程可能需要几分钟才能完成。Visual Studio 在输出日志中提供有关部署进度的状态更新，您可以通过观看这些更新来了解有关发布工作原理的大量信息！你将看到该过程涉及创建资源组、Azure 容器注册表、Log Analytics 工作区和 Azure 容器应用环境。然后，将应用部署到 Azure 容器应用环境。

5. 发布完成后，Visual Studio 会在环境屏幕底部显示资源 URL。使用这些链接可查看已部署的各种资源。选择 **webfrontend** URL 以打开浏览器，以访问已部署的应用。

    ![A screenshot of the completed publishing process and deployed resources.](media/vs-publish-complete.png)

## 使用 Azure Developer CLI (azd) 部署应用

### 安装 Azure Developer CLI

安装 `azd` 的过程因您的操作系统而异，但可以通过广泛使用的 `winget`、`brew`、`apt` 或直接通过 `curl` 来完成。要安装 `azd`，请参阅 [Install Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd).

### 初始化模板

1. 打开一个新的终端窗口，然后使用 `cd` 命令进入 .NET Aspire 项目的根目录。
1. 执行 `azd init` 命令，使用 `azd` 初始化您的项目，这将检查本地目录结构并确定应用程序的类型。

    ```console
    azd init
    ```

    更信息的关于 `azd init` 命令的内容, 请查阅 [azd init](https://learn.microsoft.com/azure/developer/azure-developer-cli/reference#azd-init).
2. 如果这是您第一次初始化应用程序，`azd` 会提示您输入环境名称:

    ```console
    Initializing an app to run on Azure (azd init)
    
    ? Enter a new environment name: [? for help]
    ```

    输入所需的环境名称以继续。有关使用 `azd` 管理环境的更多信息, 请查阅 [azd env](https://learn.microsoft.com/azure/developer/azure-developer-cli/reference#azd-env).
3. 当 `azd` 提示您使用两个应用程序初始化选项, 选择 **Use code in the current directory** 。

    ```console
    ? How do you want to initialize your app?  [Use arrows to move, type to filter]
    > Use code in the current directory
      Select a template
    ```

4. 在扫描目录结构之后, `azd` 提示您确认它找到了正确的 .NET Aspire _AppHost_ 项目。选择 **Confirm and continue initializing my app** 选项.

    ```console
    Detected services:
    
      .NET (Aspire)
      Detected in: D:\source\repos\letslearn-dotnet-aspire\complete\AppHost\AppHost.csproj
    
    azd will generate the files necessary to host your app on Azure using Azure Container Apps.
    
    ? Select an option  [Use arrows to move, type to filter]
    > Confirm and continue initializing my app
      Cancel and exit
    ```

5. `azd` 提供 .NET Aspire 解决方案中的每个项目，并提示您确定要部署的项目，并对所有 Internet 流量公开开放 HTTP 入口。仅选择 `myweatherhub`（使用 ↓ 和 Space 键），因为你希望 API 对 Azure 容器应用环境是私有的，并且 _不_ 公开可用。 

    ```console
    ? Select an option Confirm and continue initializing my app
    By default, a service can only be reached from inside the Azure Container Apps environment it is running in. Selecting a service here will also allow it to be reached from the Internet.
    ? Select which services to expose to the Internet  [Use arrows to move, space to select, <right> to all, <left> to none, type to filter]
      [ ]  apiservice
    > [x]  myweatherhub
    ```

6. 最后, 指定 Environment name（环境名称），该名称用于命名 Azure 中预置的资源并管理不同的环境，例如 `dev` 和 `prod`。

    ```console
    Generating files to run your app on Azure:
    
      (✓) Done: Generating ./azure.yaml
      (✓) Done: Generating ./next-steps.md
    
    SUCCESS: Your app is ready for the cloud!
    You can provision and deploy your app to Azure by running the azd up command in this directory. For more information on configuring your app, see ./next-steps.md
    ```

`azd` 生成多个文件并将它们放入工作目录中。这些文件是：

- _azure.yaml_: 描述应用中的服务（如 .NET Aspire AppHost 项目），并将它们映射到 Azure 资源。
- _.azure/config.json_: 通知 `azd` 当前活动环境的配置文件
- _.azure/aspireazddev/.env_: 包含特定于用来覆盖环境变量的信息。
- _.azure/aspireazddev/config.json_: 通知 `azd` 哪些服务在此环境中应具有公共终结点的配置文件。

[](https://learn.microsoft.com/dotnet/aspire/deployment/azure/aca-deployment?tabs=visual-studio%2Cinstall-az-windows%2Cpowershell&pivots=azure-azd#deploy-the-app)

### 部署应用

一旦 `azd` 完成初始化, 就可以使用一条命令来执行预置和部署过程, [azd up](https://learn.microsoft.com/azure/developer/azure-developer-cli/reference#azd-up).

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

首先，在 `azd package` 阶段将项目打包到容器中，然后是 `azd provision` 阶段，在此期间将预配应用程序所需的所有 Azure 资源。

在 `provision` 完成后，将执行 `azd deploy`。在此阶段，项目将作为容器推送到 Azure Container Registry 实例中，然后用于创建 Azure 容器应用的新版本，代码将在其中托管。

此时，应用已部署和配置，你可以打开 Azure 门户并浏览资源。

## 清理资源

当您不再需要您创建的 Azure 资源时，运行以下 Azure CLI 命令以删除资源组。删除资源组也会删除其中包含的资源。

```console
az group delete --name <your-resource-group-name>
```
