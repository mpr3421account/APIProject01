// See https://aka.ms/new-console-template for more information
using Consumer.api01;
using Flurl;
using Flurl.Http;
using System.Threading.Channels;

Console.WriteLine("Hello, World!");

string url = "https://localhost:44390/";

Item task1 = new Item();

task1.Id = 1;
task1.Name = "Pagar Conta";
task1.Finished = true;

Item task2 = new Item();

task2.Id = 2;
task2.Name = "Negar conta";
task2.Finished = true;

Item task3 = new Item();

task3.Id = 3;
task3.Name = "Receber DinDin";
task3.Finished = false;


//add a task by POST request
string endpoint = url + "api/TaskItems/";

Console.WriteLine("Incluir: ");

//slow down the request, waiting for API starts
//Thread.Sleep(new TimeSpan(0,0,30));

//flur => post
await endpoint.PostJsonAsync(task1);
await endpoint.PostJsonAsync(task2);
await endpoint.PostJsonAsync(task3);



//read the tasks list by GET request
IEnumerable<Item> listTasks = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach(var item in listTasks)
{
    Console.WriteLine($"The task {item.Name} is {item.Finished}");
}
Console.WriteLine("Vamos alterar: ");



//change by PUT request
Console.WriteLine("Input the ID to update: ");
int id = int.Parse(Console.ReadLine());
string endpoint_update = url + $"api/TaskItems/{id}";

task1.Id = 1;
task1.Name = "Pagar Conta porra nenhuma";
task1.Finished = false;

task2.Id = 2;
task2.Name = "Negar Conta é meu sonho";
task2.Finished = false;

task3.Id = 3;
task3.Name = "Receber DinDin tá difícil";
task3.Finished = true;

//flur => Put
await endpoint.PutJsonAsync(task1);
await endpoint.PutJsonAsync(task2);
await endpoint.PutJsonAsync(task3);

//read again
listTasks = (IEnumerable<Item>)await endpoint.GetJsonAsync<Item>();

foreach (var item in listTasks)
{
    Console.WriteLine($"The task {item.Name} is {item.Finished}");
}
Console.WriteLine("Vamos deletar: ");


//delete by DELETE request

//read one more time

Console.WriteLine("Press any key to start the application");
Console.Read();