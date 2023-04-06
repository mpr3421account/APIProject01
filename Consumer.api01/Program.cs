// See https://aka.ms/new-console-template for more information
using Consumer.api01;
using Flurl;
using Flurl.Http;

Console.WriteLine("Hello, World!");

string url = "https://localhost:44390/";

Item tarefa1 = new Item();

tarefa1.Id = 1;
tarefa1.Name = "Pagar Conta";
tarefa1.Finished = true;

Item tarefa2 = new Item();

tarefa2.Id = 2;
tarefa2.Name = "Negar conta";
tarefa2.Finished = true;

Item tarefa3 = new Item();

tarefa3.Id = 3;
tarefa3.Name = "Receber DinDin";
tarefa3.Finished = false;


//add a task by POST request
string endpoint = url + "api/TaskItems";

//slow down the request, waiting for API starts
//Thread.Sleep(new TimeSpan(0,0,30));

//flur
endpoint.PostJsonAsync(tarefa1);
endpoint.PostJsonAsync(tarefa2);
endpoint.PostJsonAsync(tarefa3);

//read the tasks list by GET request
IEnumerable<Item> listTasks = await endpoint.GetJsonAsync<IEnumerable<Item>>();

foreach(var item in listTasks)
{
    Console.WriteLine($"The task {item.Name} is {item.Finished}");
}

//change by PUT request

//read again

//delete by DELETE request

//read one more time

Console.WriteLine("Press any key to start the application");
Console.Read();