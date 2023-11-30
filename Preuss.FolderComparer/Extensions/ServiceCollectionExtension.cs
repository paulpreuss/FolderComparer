using Microsoft.Extensions.DependencyInjection;
using Preuss.FolderComparer.Abstractions.Processors;
using Preuss.FolderComparer.Processors;
using Preuss.FolderComparer.Views;

namespace Preuss.FolderComparer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupViews(this IServiceCollection services) => services
        .AddSingleton<MainView>()
        .AddSingleton<ResultView>();

    public static IServiceCollection SetupProcessors(this IServiceCollection services) => services
        .AddSingleton<IResultProcessor, ResultProcessor>();
}