# Stage 1
FROM microsoft/aspnetcore-build as builder
WORKDIR /src

 # Caches restore result by copying csproj file separately
 COPY ./src/gateway/OpenBrisk.Gateway/*.csproj .
 RUN dotnet restore

# Copy, restore and build solution.
COPY ./src/gateway/OpenBrisk.Gateway .
RUN dotnet restore
RUN dotnet publish --output /app/ --configuration Release

# Stage 2
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "OpenBrisk.Gateway.dll"]
