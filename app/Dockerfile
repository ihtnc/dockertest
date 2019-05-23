FROM microsoft/dotnet:sdk AS build-env

WORKDIR /app
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:aspnetcore-runtime

WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_URLS http://+:5100
EXPOSE 5100

ENTRYPOINT ["dotnet", "app.dll"]
