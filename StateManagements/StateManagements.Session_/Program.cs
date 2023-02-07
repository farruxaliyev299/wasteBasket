using StateManagements.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Code_Academy_Session_Denemeleri";
    options.IdleTimeout = TimeSpan.FromSeconds(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ModelsConfiguration(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();

/*
 
sln uzantisinin oldugu dizin icerisinde calıstiriniz.


dotnet ef migrations add initialize --project StateManagements.Models --startup-project  StateManagements.Session_ --output-dir  Migrations
dotnet ef database update           --project StateManagements.Models --startup-project  StateManagements.Session_
 */