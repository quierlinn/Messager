using Messager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var services = builder.Services;
builder.Services.AddDbContext<ChatContext>(options => 
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
services.AddControllers();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();

app.Run();