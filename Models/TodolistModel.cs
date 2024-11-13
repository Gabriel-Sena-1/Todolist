
using System.Runtime.InteropServices;

namespace Todolist.Models;

public class TodolistModel{
    public TodolistModel(string title, string text){
        Id = Guid.NewGuid();
        Title = title;
        Text = text;
    }

    public Guid Id {get; set;}
    public String Title{get; private set;} = String.Empty;

    public String Text{get; private set;} = String.Empty;
    public String Status{get; private set;} = "ativo";

    public void ChangeTitle(string title)
    {
        Title = title;
    }
    
    public void ChangeText(string text)
    {
        Text = text;
    }
    
    public void ChangeStatus()
    {
        Status = "feito";
    }

    
}