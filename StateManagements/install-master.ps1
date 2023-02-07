docker-compose --env-file ./config/.env.dev up -d --build

# Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope LocalMachine



dotnet ef database update --project StateManagements.Models --startup-project  StateManagements.Session_