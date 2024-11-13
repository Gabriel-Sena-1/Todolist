using Microsoft.EntityFrameworkCore;
using Todolist.Models;

namespace Todolist.Data;

public class TodolistContext : DbContext
{
    public DbSet<TodolistModel> Todo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=todolist.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}