using Microsoft.Extensions.DependencyInjection;
using Preuss.FolderComparer.Views;

namespace Preuss.FolderComparer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection SetupViews(this IServiceCollection services) => services
        .AddSingleton<MainView>()
        .AddSingleton<ResultView>();
}