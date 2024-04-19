namespace CrimeData.Services.Services.Models.Response
{
    public record FilterResponse
    {
        public List<FilterItemResponse> Cities { get; set; } = new List<FilterItemResponse>();
        public List<FilterItemResponse> ApiSources { get; set; } =  new List<FilterItemResponse>();
    }
}
