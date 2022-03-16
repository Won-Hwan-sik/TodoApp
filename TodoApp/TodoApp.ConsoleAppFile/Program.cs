using System;
using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.ConsoleAppFile
{
    class Program
    {
        static void Main(string[] args)
        {
            ITodoRepository _repository = new TodoRepositoryInFile(@"C:\Temp\TodoApp\Todos.txt");
            List<Todo> todos = new List<Todo>();
            todos = _repository.GetAll();

            foreach (var rv in todos)
            {
                Console.WriteLine($"[{rv.Id}] {rv.Title} : {rv.IsDone}");
            }

            Console.WriteLine($"---------------------------");

            Todo todo = new Todo() { Title = "Database", IsDone = true };
            _repository.Add(todo);
            todos = _repository.GetAll();

            foreach (var rv in todos)
            {
                Console.WriteLine($"[{rv.Id}] {rv.Title} : {rv.IsDone}");
            }
        }
    }
}
