using Microsoft.EntityFrameworkCore;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TodoContext>(options =>options.UseSqlServer(connectionString));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer(); // This one discovers the API endpoints.
builder.Services.AddSwaggerGen(); // This one generates the documentation.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // This one enables the documentation file.
    app.UseSwaggerUI(); // This one builds the interactive webpage from the file.
}

app.UseHttpsRedirection();

// Get all todos
app.MapGet("/todos", async (TodoContext context) =>
    await context.Todos.ToListAsync());

// Get a single todo by its Id
app.MapGet("/todos/{id}", async (TodoContext context, int id) =>
    await context.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

// Create a new todo
app.MapPost("/todos", async (TodoContext context, Todo todo) =>
{
    context.Todos.Add(todo);
    await context.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
});

// Update a todo
app.MapPut("/todos/{id}", async (TodoContext context, int id, Todo inputTodo) =>
{
    var todo = await context.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

// Delete a todo
app.MapDelete("/todos/{id}", async (TodoContext context, int id) =>
{
    if (await context.Todos.FindAsync(id) is Todo todo)
    {
        context.Todos.Remove(todo);
        await context.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.Run();