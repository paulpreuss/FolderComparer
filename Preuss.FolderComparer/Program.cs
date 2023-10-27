using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Preuss.FolderComparer.Abstractions.Processors;
using Preuss.FolderComparer.Extensions;
using Preuss.FolderComparer.Processors;
using Preuss.FolderComparer.Views;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IArgumentsProcessor>(mv => new ArgumentsProcessor(args));
        services.SetupViews();
    }).Build();

await builder.RunAsync();

var view = builder.Services.GetRequiredService<MainView>();
view.Print();