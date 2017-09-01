using Models.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var person = new Person()
                {
                    CPF = "999999999-99",
                    Name = "Rodrigo",
                    Old = 21,
                    Surname = "Assis"
                };
                
                Console.WriteLine("Pressione enter para cadastrar a pessoa");
                Console.ReadLine();

                var result = client.PostAsJsonAsync("http://localhost:8080/v1/persons", person).Result;

                // string com o json do person
                var getperson = client.GetStringAsync($"http://localhost:8080/v1/persons/0").Result;

                // converter para object
                var personResult = JsonConvert.DeserializeObject<Person>(getperson);

                Console.WriteLine($"Name: {personResult.Name} {personResult.Surname}");
                Console.WriteLine($"CPF: {personResult.CPF}");
                Console.ReadLine();
            }
        }
    }
}
