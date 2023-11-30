using System.IO.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Preuss.FolderComparer.Abstractions.Processors;
using Preuss.FolderComparer.Extensions;
using Preuss.FolderComparer.Processors;
using Preuss.FolderComparer.Views;
using Preuss.FolderComparer.Comparer.Extensions;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder()
    .ConfigureLogging((context, logging) =>
    {
        logging.ClearProviders();
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<IArgumentsProcessor>(_ => new ArgumentsProcessor(args));
        services.AddSingleton<IFileSystem, FileSystem>();
        services.SetupLogic();
        services.SetupProcessors();
        services.SetupViews();
    }).Build();

await builder.StartAsync();

var view = builder.Services.GetRequiredService<MainView>();
view.Print();

await builder.StopAsync();