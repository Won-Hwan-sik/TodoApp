using System;
using TodoApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoApp.Tests.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string url = @"https://localhost:44301/api/Todos";

            using (var client = new HttpClient())
            {
                // 데이터 전송
                var json = JsonConvert.SerializeObject(new Todo() { Title = "HttpClient", IsDone = true });
                var post = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(url, post);

                // 데이터 수신
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var todos = JsonConvert.DeserializeObject<List<Todo>>(result);

                foreach (var rv in todos)
                {
                    Console.WriteLine($"[{rv.Id}] {rv.Title} : {rv.IsDone}");
                }
            }

        }
    }
}
