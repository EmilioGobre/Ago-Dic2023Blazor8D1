using LasPollasHermanas.Server.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:5289")
        .AllowAnyHeader()
        .AllowAnyMethod();
    }));
var connectionString = builder.Configuration.GetConnectionString("DildoStoreContext");
builder.Services.AddSqlServer<DildoStoreContext>(connectionString);
var app = builder.Build();
app.UseCors();
var dildoGroup = app.MapGroup("/dildos").WithParameterValidation();
var userGroup = app.MapGroup("/users").WithParameterValidation();
var compradosGroup = app.MapGroup("/comprados").WithParameterValidation();
#region Entry Points Users
// EndPoint
// GET User
userGroup.MapGet("/", async (DildoStoreContext context) =>
await context.Users.AsNoTracking().ToListAsync());

// GET/User/{id}
userGroup.MapGet("/ById/{id}", async (int id, DildoStoreContext context) =>
{
    Users? user = await context.Users.FindAsync(id);
    if (user is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

// GET/email
userGroup.MapGet("/ByEmail/{id}/email", async (int id, DildoStoreContext context) =>
{
    Users? user = await context.Users.FindAsync(id);
    if (user is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(user.Email);
});

// POST/dildos
userGroup.MapPost("/", async (Users user, DildoStoreContext context) =>
{
    context.Users.Add(user);
    await context.SaveChangesAsync();
    return Results.CreatedAtRoute("GetUsers",
    new { id = user.IdUser }, user);
}).WithName("GetUsers");

// PUT/dildos/{id}
userGroup.MapPut("/{id}", async (int id, Users updatedUser, DildoStoreContext context) =>
{
    var rowsAffected = await context.Users.Where(
        user => user.IdUser == id)
        .ExecuteUpdateAsync(updates =>
        updates.SetProperty(user => user.Name, updatedUser.Name)
               .SetProperty(user => user.Sername, updatedUser.Sername)
               .SetProperty(user => user.Email, updatedUser.Email)
               .SetProperty(user => user.Password, updatedUser.Password)
               .SetProperty(user => user.Puesto, updatedUser.Puesto));

    return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});

userGroup.MapDelete("/{id}", async (int id, DildoStoreContext context) =>
{
    var rowsAffected = await context.Users.Where(
        user => user.IdUser == id)
        .ExecuteDeleteAsync();
    return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});

#endregion
#region Entry Points Dildos

// EndPoint
// GET Dildos
dildoGroup.MapGet("/", async (DildoStoreContext context) =>
await context.Dildos.AsNoTracking().ToListAsync());

// GET/Dildo/{id}
dildoGroup.MapGet("/{id}", async (int id, DildoStoreContext context) =>
{
    Dildo? dildo = await context.Dildos.FindAsync(id);
    if (dildo is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(dildo);
});

// POST/dildos
dildoGroup.MapPost("/", async (Dildo dildo, DildoStoreContext context) =>
{
    context.Dildos.Add(dildo);
    await context.SaveChangesAsync();
    return Results.CreatedAtRoute("GetDildo",
    new { id = dildo.IdDildo }, dildo);
}).WithName("GetDildo");

// PUT/dildos/{id}
dildoGroup.MapPut("/{id}", async (int id, Dildo updatedDildo, DildoStoreContext context) =>
{
    var rowsAffected = await context.Dildos.Where(
        dildo => dildo.IdDildo == id)
        .ExecuteUpdateAsync(updates =>
        updates.SetProperty(dildo => dildo.Name, updatedDildo.Name)
               .SetProperty(dildo => dildo.Price, updatedDildo.Price)
               .SetProperty(dildo => dildo.Size, updatedDildo.Size)
               .SetProperty(dildo => dildo.ExpireDate, updatedDildo.ExpireDate)
               .SetProperty(dildo => dildo.Material, updatedDildo.Material)
               .SetProperty(dildo => dildo.Color, updatedDildo.Color)
               .SetProperty(dildo => dildo.Stock, updatedDildo.Stock));

    return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});

dildoGroup.MapDelete("/{id}", async (int id, DildoStoreContext context) =>
{
    var rowsAffected = await context.Dildos.Where(
        dildo => dildo.IdDildo == id)
        .ExecuteDeleteAsync();
    return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});
dildoGroup.MapGet("/search", async (string query, DildoStoreContext context) =>
{
    var result = await context.Dildos
        .Where(d =>
            d.Name.Contains(query) ||
            d.Price.ToString().Contains(query) ||
            d.Size.ToString().Contains(query) ||
            d.ExpireDate.ToString().Contains(query) ||
            d.Material.Contains(query) ||
            d.Color.Contains(query) ||
            d.Stock.ToString().Contains(query))
        .AsNoTracking()
        .ToListAsync();

    return Results.Ok(result);
});
#endregion
#region Entry points Compras
// EndPoint
// GET compras

// GET/compras/{id}
compradosGroup.MapGet("/{id}", async (int id, DildoStoreContext context) =>
{
    var dildosComprados = context.dildosComprados
        .Where(dc => dc.UserId == id)
        .Include(dc => dc.Dildo)
        .Select(dc => new
        {
            dc.Id,
            dc.Dildo,
            dc.comprado,
        })
        .ToList();

    return Results.Ok(dildosComprados);
});

// POST/compras
compradosGroup.MapPost("/", async (dildosComprados dildoComprado, DildoStoreContext context) =>
{

    dildoComprado.comprado = DateTime.Now;

    var dildo = await context.Dildos.FindAsync(dildoComprado.DildoId);

    if (dildo == null)
    {
        return Results.NotFound(new { message = "Dildo no encontrado" });
    }

    if (dildo.Stock >= 1)
    {
        dildo.Stock--; // Decrementa el stock en 1 (ajusta esto según tus necesidades).

        // Agrega la compra a la base de datos.
        context.dildosComprados.Add(dildoComprado);
        await context.SaveChangesAsync();

        // Devuelve una respuesta Ok o un objeto que indique que la operación fue exitosa.
        return Results.Ok(new { message = "Dildo comprado agregado exitosamente" });
    }
    else
    {
        return Results.BadRequest(new { message = "Stock insuficiente" });
    }
}).WithName("GetDildosComprados");

compradosGroup.MapDelete("/{id}", async (int id, DildoStoreContext context) =>
{
    var rowsAffected = await context.dildosComprados.Where(
        comprado => comprado.Id == id)
        .ExecuteDeleteAsync();
    return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});

#endregion
app.Run();
