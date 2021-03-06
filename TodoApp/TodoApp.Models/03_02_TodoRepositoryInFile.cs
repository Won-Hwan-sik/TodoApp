using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TodoApp.Models
{
    public class TodoRepositoryInFile : ITodoRepository
    {
        private readonly string _filePath = string.Empty;
        private static List<Todo> _todos = new List<Todo>();

        public TodoRepositoryInFile()
        {
            //_todos = new List<Todo>
            //{
            //    new Todo {Id = 1, Title = "ASP.NET Core 학습", IsDone = false},
            //    new Todo {Id = 2, Title = "Blazor 학습", IsDone = false},
            //    new Todo {Id = 3, Title = "C#.net Core 학습", IsDone = true},
            //};
        }

        public TodoRepositoryInFile(string filePath)
        {
            this._filePath = filePath;
            string[] todos = File.ReadAllLines(filePath, Encoding.Default);

            foreach (var t in todos)
            {
                string[] line = t.Split(',');
                _todos.Add(new Todo()
                {
                    Id = Convert.ToInt32(line[0]),
                    Title = line[1].ToString(),
                    IsDone = Convert.ToBoolean(line[2]),
                });
            }
        }

        // 인-메모리 데이터베이스 사용 영역
        public void Add(Todo model)
        {
            model.Id = _todos.Max(t => t.Id) + 1;
            _todos.Add(model);

            string data = string.Empty;
            foreach (var t in _todos)
            {
                data += $"{t.Id},{t.Title},{t.IsDone}{Environment.NewLine}";
            }

            using (StreamWriter sw =  new StreamWriter(_filePath))
            {
                sw.Write(data);
                sw.Close();
                //sw.Dispose();
            }
        }

        public List<Todo> GetAll()
        {
            return _todos.ToList();
        }
    }

}
