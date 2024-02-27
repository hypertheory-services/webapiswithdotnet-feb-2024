using IssuesApi.Services;

namespace IssuesApi;

public static class DevelopmentSeedData
{
    public static void InitializeSoftwareCatalog(IssuesDataContext context)
    {
        context.Database.EnsureCreated();
        // Magic!

        context.SaveChangesAsync();
    }
}
