FROM microsoft/dotnet:2.2-sdk AS build
COPY Customer/*.csproj ./app/Customer/
WORKDIR /app/Customer
RUN dotnet restore

COPY Customer/. ./Customer/
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

FROM microsoft/dotnet:2.2-runtime AS runtime
ENV ASPNETCORE_URLS http://+:80
WORKDIR /app
COPY --from=build /app/Customer/out ./
ENTRYPOINT ["dotnet", "Customer.dll"]