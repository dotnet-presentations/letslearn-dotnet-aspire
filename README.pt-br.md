# Vamos aprender sobre .NET Aspire

Venha aprender tudo sobre o [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/), um novo conjunto de ferramentas preparado para a nuvem, ideal para construir aplicações distribuídas, fáceis de monitorar e prontas para produção. O .NET Aspire pode ser adicionado a qualquer aplicação, independentemente do tamanho e da escala, ajudando você a desenvolver melhores aplicações mais rapidamente.

O .NET Aspire simplifica o desenvolvimento de aplicações com:

- **Orquestração**: Orquestração integrada com um fluxo de trabalho simples, mas poderoso. Use C# e APIs familiares sem uma linha de YAML. Adicione facilmente serviços populares na nuvem, conecte-os aos seus projetos e execute localmente com um único clique.
- **Identificação de serviços**: Injeção automática das informações de conexão ou configurações de rede corretas, além de informações de serviços para simplificar a experiência do desenvolvedor.
- **Componentes**: Componentes nativos e integrados para serviços comuns na nuvem, como bancos de dados, filas e armazenamento. Integrado com logs, verificações de integridade, telemetria e muito mais.
- **Dashboard**: Veja dados ao vivo do OpenTelemetry sem necessidade de configuração. Iniciado por padrão ao executar, o painel do desenvolvedor do .NET Aspire mostra logs, variáveis de ambiente, rastreamentos (traces) distribuídos, métricas e mais para verificar rapidamente o comportamento do aplicativo.
- **Implantação**: Gerencia a injeção das informações de conexão ou configurações de rede corretas e informações de serviços para simplificar a experiência do desenvolvedor.
- **E muito mais**: O .NET Aspire está repleto de recursos que os desenvolvedores vão adorar e que ajudarão a aumentar sua produtividade.

Saiba mais sobre o .NET Aspire com os seguintes recursos (em Inglês):
- [Documentação](https://learn.microsoft.com/dotnet/aspire)
- [Treinamento do Microsoft Learn](https://learn.microsoft.com/training/paths/dotnet-aspire/)
- [Vídeos do .NET Aspire](https://aka.ms/aspire/videos)
- [Aplicativo de exemplo e referência eShop](https://github.com/dotnet/eshop)
- [Exemplos do .NET Aspire](https://learn.microsoft.com/samples/browse/?expanded=dotnet&products=dotnet-aspire)
- [Perguntas frequentes do .NET Aspire](https://learn.microsoft.com/dotnet/aspire/reference/aspire-faq)

## Localização

Os materiais deste workshop estão disponíveis nos seguintes idiomas:

- [Inglês](./README.md)
- [한국어](./README.ko.md)
- [日本語](./README.jp.md)
- [Español](./README.es.md)
- [Português (PT-BR)](./README.pt-br.md)

## Workshop

Este workshop do .NET Aspire faz parte da série [Vamos aprender .NET](https://aka.ms/letslearndotnet). Este workshop foi criado para ajudá-lo a aprender sobre o .NET Aspire e como usá-lo para construir aplicações prontas para a nuvem. Este workshop é dividido em 6 módulos:

1. [Configuração & Instalação](./workshop/localization/pt-br/1-setup.md)
1. [Padrões de serviço](./workshop/localization/pt-br/2-servicedefaults.md)
1. [Painel de desenvolvimento e orquestração](./workshop/localization/pt-br/3-dashboard-apphost.md)
1. [Identificação de serviços](./workshop/localization/pt-br/4-servicediscovery.md)
1. [Componentes](./workshop/localization/pt-br/5-components.md)
1. [Implantação](./workshop/localization/pt-br/6-deployment.md)

Um conjunto completo de slides está disponível para este workshop [aqui](./workshop/localization/pt-br/AspireWorkshop.pptx).

O projeto inicial para este workshop está localizado na pasta `start-with-api`. Este projeto é uma simples API de clima que usa a API do Serviço Nacional de Meteorologia dos Estados Unidos (NWS) para obter dados meteorológicos e uma interface web para exibir os dados do clima alimentada por Blazor.

Este workshop foi criado para ser executado em um período de 2 horas.

## Dados de demonstração

Os dados e o serviço usados para este tutorial vêm do Serviço Nacional de Meteorologia dos Estados Unidos (NWS) em https://weather.gov. Estamos usando sua especificação OpenAPI para consultar previsões meteorológicas. A especificação OpenAPI está [disponível online](https://www.weather.gov/documentation/services-web-api). Estamos usando apenas 2 métodos dessa API, e simplificamos nosso código para usar apenas esses métodos em vez de criar o cliente OpenAPI inteiro para a API NWS.
