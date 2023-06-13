using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EntityDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySql");
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddControllers();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
    
using (var scope = app.Services.CreateScope())
{
    var entityDbContext 
        = scope.ServiceProvider.GetRequiredService<EntityDbContext>();
    await entityDbContext.Database.EnsureCreatedAsync();
}


app.MapControllers();

app.Run();