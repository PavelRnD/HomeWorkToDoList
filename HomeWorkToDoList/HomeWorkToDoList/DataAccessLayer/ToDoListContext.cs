using HomeWorkToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkToDoList.DataAccessLayer
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDo> ToDoList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDo>().HasKey(todo => todo.Id);
        }
    }
}
