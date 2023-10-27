// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        
    }).Build();

await builder.RunAsync();