# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie o arquivo de projeto e restaure as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie o restante do código e construa a aplicação
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Defina o comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "CheckList.Api.dll"]

EXPOSE 5008
