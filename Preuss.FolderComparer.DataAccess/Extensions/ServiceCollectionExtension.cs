using Microsoft.Extensions.DependencyInjection;
using Preuss.FolderComparer.DataAccess.Abstractions.Repositories;
using Preuss.FolderComparer.DataAccess.Repositories;

namespace Preuss.FolderComparer.DataAccess.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection SetupViews(this IServiceCollection services) => services
       .AddSingleton<IComparableFileRepository, ComparableFileRepository>();
}
