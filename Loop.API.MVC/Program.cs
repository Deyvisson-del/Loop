using Loop.Infra.Data;
using Loop.Infra.Data.Context;
using Loop.Infra.IoC;
using Microsoft.EntityFrameworkCore;

Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.
    GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");


builder.Services.AddInfraestructure(connectionString);
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Contexto>();
    dbContext.Database.Migrate();
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();