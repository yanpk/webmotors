FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

EXPOSE 10000:80

# Build da aplicacao
COPY . ./

# Build da imagem
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/ .
ENTRYPOINT ["dotnet", "WebMotors.dll"]