FROM mcr.microsoft.com/dotnet/core/sdk:3.1

ENTRYPOINT ["dotnet", "-- build"]