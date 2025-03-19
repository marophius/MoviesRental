# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Publisher/Presentation/MoviesRental.Api/MoviesRental.Api.csproj", "src/Services/Publisher/Presentation/MoviesRental.Api/"]
COPY ["src/Shared/Queries/Infrastructure/MoviesRental.Query.Infrastructure/MoviesRental.Query.Infrastructure.csproj", "src/Shared/Queries/Infrastructure/MoviesRental.Query.Infrastructure/"]
COPY ["src/Shared/Queries/Application/MoviesRental.Query.Application/MoviesRental.Query.Application.csproj", "src/Shared/Queries/Application/MoviesRental.Query.Application/"]
COPY ["src/Shared/Queries/Domain/MoviesRental.Query.Domain/MoviesRental.Query.Domain.csproj", "src/Shared/Queries/Domain/MoviesRental.Query.Domain/"]
COPY ["src/Core/MoviesRental.Core/MoviesRental.Core.csproj", "src/Core/MoviesRental.Core/"]
COPY ["src/Services/Publisher/Infrastructure/MoviesRental.Infrastructure/MoviesRental.Infrastructure.csproj", "src/Services/Publisher/Infrastructure/MoviesRental.Infrastructure/"]
COPY ["src/Services/Publisher/Application/MoviesRental.Application/MoviesRental.Application.csproj", "src/Services/Publisher/Application/MoviesRental.Application/"]
COPY ["src/Services/Publisher/Domain/MoviesRental.Domain/MoviesRental.Domain.csproj", "src/Services/Publisher/Domain/MoviesRental.Domain/"]
RUN dotnet restore "./src/Services/Publisher/Presentation/MoviesRental.Api/MoviesRental.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Publisher/Presentation/MoviesRental.Api"
RUN dotnet build "./MoviesRental.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MoviesRental.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoviesRental.Api.dll"]