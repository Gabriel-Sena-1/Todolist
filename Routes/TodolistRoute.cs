using Microsoft.EntityFrameworkCore;
using Todolist.Data;
using Todolist.Models;

namespace Todolist.Routes;

public static class TodolistRoute{

    public static void TodolistRoutes(this WebApplication app)
    {
        var route = app.MapGroup("todo");
        route.MapPost("", async (TodolistRequest req, TodolistContext context) =>
        {
            var todo = new TodolistModel(req.title, req.text);
            await context.AddAsync(todo);
            await context.SaveChangesAsync();
            return Results.Ok(todo);
        });
        
        route.MapGet("", async (TodolistContext context) =>
        {
            var todos = await context.Todo.ToListAsync();
            return Results.Ok(todos);
        });

        route.MapPut("{id:guid}", async (Guid id, TodolistRequest req, TodolistContext context) =>
        {
            var todo = await context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return Results.NotFound();

            todo.ChangeTitle(req.title);
            todo.ChangeText(req.text);
            await context.SaveChangesAsync();

            return Results.Ok(todo);
        });

        route.MapDelete("/done/{id:guid}", async (Guid id, TodolistContext context) =>
        {
            var todo = await context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
                return Results.NotFound();

            todo.ChangeStatus();
            await context.SaveChangesAsync();

            return Results.Ok(todo);
        });

        route.MapDelete("{id:guid}", async (Guid id, TodolistContext context) =>{
            var todo = await context.Todo.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
            {
                return Results.NotFound();
            }

            context.Todo.Remove(todo);
            await context.SaveChangesAsync();

            return Results.Ok();
        });
    }
}