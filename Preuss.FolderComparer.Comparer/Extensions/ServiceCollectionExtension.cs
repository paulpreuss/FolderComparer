using Microsoft.Extensions.DependencyInjection;
using Preuss.FolderComparer.Comparer.Abstractions.Repositories;
using Preuss.FolderComparer.Comparer.Repositories;

namespace Preuss.FolderComparer.Comparer.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection SetupViews(this IServiceCollection services) => services
       .AddSingleton<IComparableFileRepository, ComparableFileRepository>();
}
