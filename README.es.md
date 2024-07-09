# Aprendamos .NET Aspire

Ven y aprende todo sobre [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/), una nueva pila de tecnología lista para la nube para construir aplicaciones distribuidas, observables y listas para producción. .NET Aspire se puede agregar a cualquier aplicación, independientemente de su tamaño y escala, para ayudarte a construir aplicaciones mejores y más rápidas.

.NET Aspire simplifica el desarrollo de aplicaciones con:

- **Orquestación**: Orquestación incorporada con un motor de flujo de trabajo simple pero potente. Utiliza C# y API familiares sin necesidad de YAML. Agrega fácilmente servicios en la nube populares, conecta a tus proyectos y ejecútalos localmente con un solo clic.
- **Descubrimiento de servicios**: Inyección automática de las cadenas de conexión correctas o configuraciones de red y la información de descubrimiento de servicios para simplificar la experiencia del desarrollador.
- **Componentes**: Componentes incorporados para servicios en la nube comunes como bases de datos, colas y almacenamiento. Integrados con registro, comprobaciones de salud, telemetría y más.
- **Panel de control**: Visualiza datos en vivo de OpenTelemetry sin necesidad de configuración. El panel de control para desarrolladores de .NET Aspire muestra registros, variables de entorno, trazas distribuidas, métricas y más para verificar rápidamente el comportamiento de la aplicación.
- **Despliegue**: Gestiona la inyección de las cadenas de conexión correctas o configuraciones de red y la información de descubrimiento de servicios para simplificar la experiencia del desarrollador.
- **Y mucho más**: .NET Aspire está repleto de características que a los desarrolladores les encantarán y que te ayudarán a ser más productivo.

Obtén más información sobre .NET Aspire con los siguientes recursos:
- [Documentación](https://learn.microsoft.com/dotnet/aspire)
- [Ruta de aprendizaje de Microsoft Learn](https://learn.microsoft.com/training/paths/dotnet-aspire/)
- [Videos de .NET Aspire](https://aka.ms/aspire/videos)
- [Aplicación de muestra de referencia eShop](https://github.com/dotnet/eshop)
- [Ejemplos de .NET Aspire](https://learn.microsoft.com/samples/browse/?expanded=dotnet&products=dotnet-aspire)
- [Preguntas frecuentes de .NET Aspire](https://learn.microsoft.com/dotnet/aspire/reference/aspire-faq)

## Localización

Estos materiales del taller de .NET Aspire están disponibles en los siguientes idiomas:

- [Inglés](./README.md)
- [한국어](./README.ko.md)
- [Português (PT-BR)](./README.pt-br.md)

## Taller

Este taller de .NET Aspire forma parte de la serie [Aprendamos .NET](https://aka.ms/letslearndotnet). Este taller está diseñado para ayudarte a aprender sobre .NET Aspire y cómo utilizarlo para construir aplicaciones listas para la nube. El taller se divide en 6 módulos:

1. [Configuración e instalación](./workshop/localization/es/1-setup.md)
1. [Valores predeterminados de servicio](./workshop/localization/es/2-servicedefaults.md)
1. [Panel de control del desarrollador y orquestación](./workshop/localization/es/3-dashboard-apphost.md)
1. [Descubrimiento de servicios](./workshop/localization/es/4-servicediscovery.md)
1. [Componentes](./workshop/localization/es/5-components.md)
1. [Despliegue](./workshop/localization/es/6-deployment.md)

Un conjunto completo de diapositivas está disponible para este taller [aquí](./workshop/localization/es/AspireWorkshop.pptx).

El proyecto inicial para este taller se encuentra en la carpeta `start-with-api`. Este proyecto es una API de clima simple que utiliza la API del Servicio Meteorológico Nacional para obtener datos meteorológicos y un frontend web para mostrar los datos meteorológicos impulsado por Blazor.

Este taller está diseñado para completarse en un marco de tiempo de 2 horas.

## Datos de demostración

Los datos y servicios utilizados en este tutorial provienen del Servicio Meteorológico Nacional de los Estados Unidos (NWS) en https://weather.gov. Estamos utilizando su especificación de OpenAPI para consultar pronósticos del clima. La especificación de OpenAPI está [disponible en línea](https://www.weather.gov/documentation/services-web-api). Estamos utilizando solo 2 métodos de esta API y hemos simplificado nuestro código para utilizar solo esos métodos en lugar de crear el cliente completo de OpenAPI para la API de NWS.
