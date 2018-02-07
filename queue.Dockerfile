# Stage 1
FROM microsoft/aspnetcore-build as builder
WORKDIR /src

 # Caches restore result by copying csproj file separately
 COPY ./src/queue/OpenBrisk.Queue/*.csproj .
 RUN dotnet restore

# Copy the rest and build.
COPY ./src/queue/OpenBrisk.Queue .
RUN dotnet restore
RUN dotnet publish --output /app/ --configuration Release

# Stage 2
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "OpenBrisk.Queue.dll"]
