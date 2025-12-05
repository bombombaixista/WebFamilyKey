using Microsoft.EntityFrameworkCore;
using WebFamilyKey2.Data;
using WebFamilyKey2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// ✅ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Banco de dados (PostgreSQL no Railway)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ✅ Seed Data: cria Tenant inicial se não existir
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    if (!db.Tenants.Any())
    {
        db.Tenants.Add(new Tenant { Name = "Default Tenant" });
        db.SaveChanges();
    }
}

// ✅ Swagger habilitado em qualquer ambiente (dev e produção)
app.UseSwagger();
app.UseSwaggerUI();

// Middlewares padrão
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
