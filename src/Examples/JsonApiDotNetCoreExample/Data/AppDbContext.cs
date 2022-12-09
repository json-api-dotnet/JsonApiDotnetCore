using JetBrains.Annotations;
using JsonApiDotNetCoreExample.Models;
using Microsoft.EntityFrameworkCore;

// @formatter:wrap_chained_method_calls chop_always

namespace JsonApiDotNetCoreExample.Data;

[UsedImplicitly(ImplicitUseTargetFlags.Members)]
public sealed class AppDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<MyDto> MyDtos => Set<MyDto>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // When deleting a person, un-assign him/her from existing todo items.
        builder.Entity<Person>()
            .HasMany(person => person.AssignedTodoItems)
            .WithOne(todoItem => todoItem.Assignee!);

        // When deleting a person, the todo items he/she owns are deleted too.
        builder.Entity<TodoItem>()
            .HasOne(todoItem => todoItem.Owner)
            .WithMany();

        builder.Entity<MyDto>()
            .Property(myDto => myDto.EmployeeId)
            .HasConversion<int?>(
                // Convert to DB type
                value => value == null ? null : int.Parse(value),
                // Convert to model type
                value => value.ToString());
    }
}
