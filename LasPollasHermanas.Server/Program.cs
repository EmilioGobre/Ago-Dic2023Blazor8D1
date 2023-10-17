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
#region Entry Points Users
// EndPoint
// GET Dildos
userGroup.MapGet("/", async (DildoStoreContext context) =>
await context.Users.AsNoTracking().ToListAsync());

// GET/Dildo/{id}
userGroup.MapGet("/{id}", async (int id, DildoStoreContext context) =>
{
  Users? user = await context.Users.FindAsync(id);
  if (user is null)
  {
    return Results.NotFound();
  }
  return Results.Ok(user);
});
// GET/user/byEmail/{email}
userGroup.MapGet("/byEmail/{email}", async (string email, DildoStoreContext context) =>
{
  Users? user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
  if (user is null)
  {
    return Results.NotFound();
  }
  return Results.Ok(user);
});



// POST/dildos
userGroup.MapPost("/", async (Users user, DildoStoreContext context) =>
{
  // TODO: Where the F this id comes?
  context.Users.Add(user);
  await context.SaveChangesAsync();
  return Results.CreatedAtRoute("GetUsers",
  new { id = user.Id }, user);
}).WithName("GetUsers");

// PUT/dildos/{id}
userGroup.MapPut("/{id}", async (int id, Users updatedUser, DildoStoreContext context) =>
{
  var rowsAffected = await context.Users.Where(
      user => user.Id == id)
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
      user => user.Id == id)
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
  // TODO: Where the F this id comes?
  context.Dildos.Add(dildo);
  await context.SaveChangesAsync();
  return Results.CreatedAtRoute("GetDildo",
  new { id = dildo.Id }, dildo);
}).WithName("GetDildo");

// PUT/dildos/{id}
dildoGroup.MapPut("/{id}", async (int id, Dildo updatedDildo, DildoStoreContext context) =>
{
  var rowsAffected = await context.Dildos.Where(
      dildo => dildo.Id == id)
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
      dildo => dildo.Id == id)
      .ExecuteDeleteAsync();
  return rowsAffected == 0 ? Results.NotFound() : Results.NoContent();
});
#endregion

app.Run();