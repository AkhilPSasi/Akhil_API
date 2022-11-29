namespace Akhil_API.Models
{
    public class ProductQueryParameters : QueryParameters
    {
        public decimal? filter_MinPrice { get; set; }
        public decimal? filter_MaxPrice { get; set; }
        public string? filter_ProductName { get; set; }
        public string? filter_Description { get; set; }
        public string? filter_SearchTerm { get; set; }
    }
}
