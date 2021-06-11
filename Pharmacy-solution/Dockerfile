# DOCKER

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pharmacy", "Pharmacy"]
COPY ["Pharmacy.Initializer", "Pharmacy.Initializer"]
COPY ["Pharmacy.Services", "Pharmacy.Services"]
COPY ["Pharmacy.DTO", "Pharmacy.DTO"]
COPY ["Pharmacy.Infra.Repositories", "Pharmacy.Infra.Repositories"]
COPY ["Pharmacy.Infra.Data", "Pharmacy.Infra.Data"]
COPY ["Pharmacy.Model", "Pharmacy.Model"]
COPY ["Pharmacy.Cryptographic", "Pharmacy.Cryptographic"]
COPY ["Pharmacy.MappingDTO", "Pharmacy.MappingDTO"]
COPY ["Pharmacy.Extensions", "Pharmacy.Extensions"]
RUN dotnet restore "Pharmacy/Pharmacy.API.csproj"

WORKDIR "/src/Pharmacy"
RUN dotnet build "Pharmacy.API.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/Pharmacy"
RUN ls /src/Pharmacy
RUN dotnet publish "Pharmacy.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80
WORKDIR /app
COPY --from=publish /app/publish .
COPY . .
RUN chmod +x ./start.sh
CMD /bin/bash ./start.sh

# CMD dotnet "Pharmacy.API.dll"