namespace IssuesApi.Features.Catalog;

public record SoftwareCatalogSummaryResponseItem(Guid Id, string Title, string Version);


public record CollectionResponse<T>(IList<T> Items);


public record SoftwareItemRequestModel
{
    public string Title { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
}
