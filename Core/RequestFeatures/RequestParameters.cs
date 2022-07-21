namespace Core.RequestFeatures
{
    public abstract class RequestParameters
    {
        public string SearchTerm { get; set; } = String.Empty;
        public string OrderBy { get; set; } = String.Empty;
    }
}