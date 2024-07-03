# Let's Learn .NET Aspire

[.NET Aspire](https://learn.microsoft.com/dotnet/aspire/) について学びましょう。.NET Aspire はサイズやスケールに関係なく、あらゆるアプリケーションに追加でき、より優れたアプリケーションを迅速に構築出来ます。

.NET Aspire はアプリケーションの開発を効率化します。

- **オーケストレーション**: シンプルで協力なワークフロによる組み込みオーケストレーション。C# と慣れ親しんだ API を使用し、YAML を 1 行も書くことなく利用できます。人気のクラウドサービスを簡単に追加し、プロジェクトに接続して、ワンクリックでローカルで実行できます。
- **サービスディスカバリー**: 適切な接続文字列やネットワーク構成、サービスディスカバリー情報を自動的に挿入して、開発者の体験を簡素化します。
- **コンポーネント**: データベース、キュー、ストレージなどの一般的なクラウドサービス向けの組み込みコンポーネント。ロギング、ヘルスチェック、テレメトリなどと統合されています。
- **ダッシュボード**: 設定不要でリアルタイムの OpenTelemetry データを表示します。実行時にデフォルトで起動する .NET Aspire の開発者ダッシュボードは、ログ、環境変数、分散トレース、メトリクスなどを表示して、アプリの動作を素早く確認できます。
- **デプロイメント**: 適切な接続文字列やネットワーク構成、サービスディスカバリー情報を挿入する行い、開発者の体験を簡素化します。
- **さらに多く**: .NET Aspire には、開発者が気に入る多くの機能を備え、生産性を向上させます。

こちらのリリースを使用して、.NET Aspire についてもっと学びましょう:
- [Documentation](https://learn.microsoft.com/dotnet/aspire)
- [Microsoft Learn Training Path](https://learn.microsoft.com/en-us/training/paths/dotnet-aspire/)
- [.NET Aspire ビデオ](https://aka.ms/aspire/videos)
- [eShop Reference サンプルアプリ](https://github.com/dotnet/eshop)
- [.NET Aspire サンプル](https://learn.microsoft.com/samples/browse/?expanded=dotnet&products=dotnet-aspire)
- [.NET Aspire FAQ](https://learn.microsoft.com/dotnet/aspire/reference/aspire-faq)

## ワークショップ

この .NET Aspire ワークショップは、[Let's Learn .NET](https://aka.ms/letslearndotnet) シリーズの一部です。このワークショップは、.NET Aspire について学び、クラウドレディなアプリケーションの構築に使用する方法を学ぶために設計されています。
このワークショップは、以下の 6 つのモジュールに分かれています:

1. [Setup & Installation](./workshop/1-setup.md)
1. [Service Defaults](./workshop/2-sevicedefaults.md)
1. [Developer Dashboard & Orchestration](./workshop/3-dashboard-apphost.md)
1. [Service Discovery](./workshop/4-servicediscovery.md)
1. [Components](./workshop/5-components.md)
1. [Deployment](./workshop/6-deployment.md)

このワークショップの完全なスライドは[こちら](./workshop/AspireWorkshop.pptx)から利用できます。

このワークショップの開始プロジェクトは、`start-with-api` フォルダに格納されています。このプロジェクトは、National Weather Service API を使用して、天気データを取得し、Blazor によって提供される Web フロントエンドで天気データを表示するシンプルな天気 API です。

このワークショップは 2 時間で行うことを想定しています。

## デモ データ

このチュートリアルで使用するデータとサービスは、アメリカ国立気象局 (NWS) の https://weather.gov から提供されています。NWS の OpenAPI 仕様を使用して天気予報をクエリします。OpenAPI 仕様は [こちら](https://www.weather.gov/documentation/services-web-api) から入手できます。私たちはこの API の 2 つのメソッドのみを使用しており、NWS API の全体的な OpenAPI クライアントを作成するのではなく、そのメソッドだけを使用するようにコードを簡略化しています。

