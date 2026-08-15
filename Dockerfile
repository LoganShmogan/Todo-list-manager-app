FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ToDoAppCLI.csproj ./
RUN dotnet restore ToDoAppCLI.csproj

COPY Program.cs ./
RUN dotnet publish ToDoAppCLI.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS final
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "ToDoAppCLI.dll"]
