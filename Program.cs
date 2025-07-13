using TodoApi;

var builder = WebApplication.CreateBuilder(args);

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

// This is our new endpoint
// Get all todos
app.MapGet("/todos", () => TodoDb._todos);

// Get a single todo by its Id
app.MapGet("/todos/{id}", (int id) =>
{
    var todo = TodoDb._todos.FirstOrDefault(t => t.Id == id);
    return todo is not null ? Results.Ok(todo) : Results.NotFound();
});

// Create a new todo
app.MapPost("/todos", (Todo todo) =>
{
    var newId = TodoDb._todos.Any() ? TodoDb._todos.Max(t => t.Id) + 1 : 1;
    todo.Id = newId;
    TodoDb._todos.Add(todo);
    return Results.Created($"/todos/{todo.Id}", todo);
});

// Additing a todo
app.MapPut("/todos/{id}", (int id, Todo inputTodo) =>
{
    var todo = TodoDb._todos.FirstOrDefault(t => t.Id == id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;

    return Results.NoContent();
});

// deleting a todo
app.MapDelete("/todos/{id}", (int id) =>
{
    var todo = TodoDb._todos.FirstOrDefault(t => t.Id == id);

    if (todo is null)
    {
        return Results.NotFound();
    }

    TodoDb._todos.Remove(todo);

    return Results.NoContent();
});

app.Run();