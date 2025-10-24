namespace SmartTripApp.Models
{
    public class TourSearch
    {
        public enum TourSortOption
        {
            PriceAsc,
            PriceDesc,
            NameAsc,
            NameDesc,
            DateAsc,
            DateDesc
        }

        public Country? Country { get; set; }
        public float? MinPrice { get; set; }
        public float? MaxPrice { get; set; }
        public TourSortOption? SortBy { get; set; }
    }
}
