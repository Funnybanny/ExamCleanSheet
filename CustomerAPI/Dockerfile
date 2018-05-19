FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY ExamSol.sln ./
COPY CustomerAPI/CustomerAPI.csproj CustomerAPI/
COPY DAL/DAL.csproj DAL/
COPY BE/BE.csproj BE/
COPY Converter/Converter.csproj Converter/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/CustomerAPI
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CustomerAPI.dll"]
