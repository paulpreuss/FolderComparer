using System.IO.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Preuss.FolderComparer.Abstractions.Processors;
using Preuss.FolderComparer.Extensions;
using Preuss.FolderComparer.Processors;
using Preuss.FolderComparer.Views;
using Preuss.FolderComparer.Comparer.Extensions;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IArgumentsProcessor>(mv => new ArgumentsProcessor(args));
        services.AddSingleton<IFileSystem, FileSystem>();
        services.SetupLogic();
        services.SetupViews();
    }).Build();

await builder.StartAsync();

var view = builder.Services.GetRequiredService<MainView>();
view.Print();

await builder.StopAsync();