using Todolist.Models;

namespace Todolist.Routes;

public static class TodolistRoute{

    public static void TodolistRoutes(this WebApplication app){
        app.MapGet("todo", ()=> new TodolistModel("Tarefa hoje", "vc precisa fazer n sei o que n sei o que", "1"));
    }
}