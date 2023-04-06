// See https://aka.ms/new-console-template for more information
using Consumer.api01;
using Flurl;
using Flurl.Http;

Console.WriteLine("Hello, World!");

string url = "https://localhost:7243";

Item tarefa1 = new Item();

tarefa1.Id = 1;
tarefa1.Name = "Pagar Conta";
tarefa1.Finished = true;

Item tarefa2 = new Item();

tarefa2.Id = 2;
tarefa2.Name = "Pagar Conta";
tarefa2.Finished = true;


//add a task by POST request
string endpoint = url + "api/TaskItems";

//flur
endpoint.PostJsonAsync(tarefa1);
endpoint.PostJsonAsync(tarefa2);

//read the tasks list by GET request

//change by PUT request

//read again

//delete by DELETE request

//read one more time

Console.WriteLine("Press any key to start the application");
Console.Read();