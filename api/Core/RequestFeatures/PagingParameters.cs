namespace Core.RequestFeatures
{
    public class PagingParameters : RequestParameters
    {
        private const int MaxPageSize = 40;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 5;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }
}