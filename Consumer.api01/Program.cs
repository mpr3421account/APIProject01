// See https://aka.ms/new-console-template for more information
using Consumer.api01;
using Flurl;
using Flurl.Http;
using System.Threading.Channels;

Console.WriteLine("Starting application");
//Console.Read();

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

Console.WriteLine("Adding Tasks: ");

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



//change by PUT request
Console.WriteLine("Lets Update: ");
Console.WriteLine("Input the ID to update: ");

int id = Convert.ToInt32(Console.ReadLine());
string endpoint_update = url + $"api/TaskItems/{id}";

Item task4 = new Item();
task4.Id = (1);
task4.Name = "Updated";
task4.Finished = true;

await endpoint_update.PutJsonAsync(task4);
Console.WriteLine($"Task id {id} was updated successfuly");

//read again
listTasks = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listTasks)
{
    Console.WriteLine($"The task {item.Name} is {item.Finished}");
}
Console.WriteLine("Vamos deletar: ");


//delete by DELETE request
string endpoint_delete = url + $"api/TaskItems/3";
await endpoint_delete.DeleteAsync();


//read one more time

listTasks = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach (var item in listTasks)
{
    Console.WriteLine($"The task {item.Name} is {item.Finished}");
}
Console.WriteLine("Vamos Parar aqui");