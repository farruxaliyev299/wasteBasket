dotnet ef migrations add Initialize_$(Get-Date -Format "ddMMyyyHHmmss") --project StateManagements.Models --startup-project StateManagements.Session_ --output-dir Migrations

dotnet ef database update --project StateManagements.Models --startup-project StateManagements.Session_