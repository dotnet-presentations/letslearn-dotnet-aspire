> 이 문서는 [Azure OpenAI](https://learn.microsoft.com/azure/ai-services/openai/overview)를 이용해 초벌 번역 후 검수를 진행했습니다. 따라서 번역 품질이 기대와 다를 수 있습니다. 문서 번역에 대해 제안할 내용이 있을 경우, [이슈](./issue)에 남겨주시면 확인후 반영하겠습니다.

# Let's Learn .NET Aspire

[.NET Aspire](https://learn.microsoft.com/dotnet/aspire/)는 관측이 용이하고, 프로덕션에 배포할 준비가 된 분산형 애플리케이션을 구축하기 위한 새로운 클라우드 네이티브 스택입니다. .NET Aspire는 애플리케이션의 크기와 규모에 관계없이 추가하여 더 나은 애플리케이션을 더 빠르게 구축할 수 있도록 도와줍니다.

.NET Aspire는 앱 개발을 다음과 같이 간소화합니다:

- **오케스트레이션**: 간단하면서도 강력한 워크플로우 엔진이 내장된 오케스트레이션. YAML 한 줄 없이 C#과 친숙한 API를 사용합니다. 인기 있는 클라우드 서비스를 쉽게 추가하고 프로젝트에 연결한 후 단 한 번의 클릭으로 로컬에서 실행할 수 있습니다.
- **서비스 검색(디스커버리)**: 적절한 연결 문자열이나 네트워크 구성 및 서비스 검색 정보를 자동으로 삽입하여 개발자 경험을 단순화합니다.
- **컴포넌트**: 데이터베이스, 큐, 스토리지와 같은 일반적인 클라우드 서비스를 위한 내장 컴포넌트. 로깅, 상태 점검, 텔레메트리 등을 쉽게 통합했습니다.
- **대시보드**: 별도의 설정 없이 라이브 OpenTelemetry 데이터를 볼 수 있습니다. 기본적으로 앱을 실행할 때 함께 실행되며, .NET Aspire의 개발자 대시보드는 로그, 환경 변수, 분산 추적, 메트릭 등을 표시하여 앱 동작을 빠르게 확인할 수 있습니다.
- **배포**: 적절한 연결 문자열이나 네트워크 구성 및 서비스 검색 정보를 삽입하여 개발자 경험을 단순화합니다.
- **기타**: .NET Aspire에는 개발자들이 좋아할 만한 기능들이 가득하며, 생산성을 높이는 데 도움이 됩니다.

다음 리소스를 통해 .NET Aspire에 대해 더 알아보세요:

- [문서](https://learn.microsoft.com/dotnet/aspire)
- [Microsoft Learn 교육 경로](https://learn.microsoft.com/en-us/training/paths/dotnet-aspire/)
- [.NET Aspire 비디오](https://aka.ms/aspire/videos)
- [eShop 참조 샘플 앱](https://github.com/dotnet/eshop)
- [.NET Aspire 샘플](https://learn.microsoft.com/samples/browse/?expanded=dotnet&products=dotnet-aspire)
- [.NET Aspire FAQ](https://learn.microsoft.com/dotnet/aspire/reference/aspire-faq)

## 워크샵

이 .NET Aspire 워크샵은 [Let's Learn .NET](https://aka.ms/letslearndotnet) 시리즈의 일부입니다. 이 워크샵은 .NET Aspire에 대해 배우고 이를 사용하여 클라우드-레디 애플리케이션을 구축하는 방법을 배우도록 설계되었습니다. 이 워크샵은 6개의 모듈로 나누어져 있습니다:

1. [설치 및 설정](./workshop/localisation/ko/1-setup.md)
2. [서비스 기본값](./workshop/localisation/ko/2-sevicedefaults.md)
3. [개발자 대시보드 및 오케스트레이션](./workshop/localisation/ko/3-dashboard-apphost.md)
4. [서비스 검색(디스커버리)](./workshop/localisation/ko/4-servicediscovery.md)
5. [컴포넌트](./workshop/localisation/ko/5-components.md)
6. [배포](./workshop/localisation/ko/6-deployment.md)

이 워크샵을 위한 전체 슬라이드 데크는 [여기](./workshop/localisation/ko/AspireWorkshop.pptx)에서 제공합니다.

이 워크샵의 시작 프로젝트는 `start-with-api` 폴더에 있습니다. 이 프로젝트는 National Weather Service API를 사용하여 날씨 데이터를 가져오고 Blazor로 작동하는 웹 프론트엔드를 통해 날씨 데이터를 표시하는 간단한 날씨 API입니다.

이 워크샵은 2시간 내에 완료하도록 설계했습니다.

## 데모 데이터

이 튜토리얼에서 사용한 데이터와 서비스는 [기상청](https://www.weather.go.kr/)에서 제공합니다. 기상청에서 제공하는 API 명세를 사용하여 날씨 예보를 쿼리합니다. API 사양은 [온라인에서 이용 가능](https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15084084)합니다. 우리는 이 API의 몇가지 엔드포인트만 사용하고, 전체 NWS API 클라이언트를 작성하는 대신 이 방법들만 사용하도록 코드를 단순화했습니다.
