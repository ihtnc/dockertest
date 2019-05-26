FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Project files layer
COPY /*.sln .
COPY /api/*csproj ./api/
COPY /tests/*.csproj ./tests/
RUN dotnet restore

# Publish objects layer
COPY ./api ./api/
WORKDIR /app/api
RUN dotnet publish -c Release -o out

# Test layer
WORKDIR /app/tests
COPY tests/. .
RUN dotnet test

# Runtime layer
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/api/out .

ENV ASPNETCORE_URLS http://+:5100
EXPOSE 5100

ENTRYPOINT ["dotnet", "api.dll"]
