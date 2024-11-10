
namespace Todolist.Models;

public class TodolistModel{
    public TodolistModel(string title, string text, string status){
        Id = Guid.NewGuid();
        Title = title;
        Text = text;
        Status = status;
    }

    public Guid Id {get; set;}
    public String Title{get; private set;} = String.Empty;

    public String Text{get; private set;} = String.Empty;
    public String Status{get; private set;} = String.Empty;
    
}