namespace Core.RequestFeatures;

public class PersonParameters: PagingParameters
{
    public string SearchTerm { get; set; } = String.Empty;
}