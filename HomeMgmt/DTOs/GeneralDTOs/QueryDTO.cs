namespace HomeMgmt.DTOs.GeneralDTOs
{
    public class QueryDTO
    {
        public int PageNumber { get; set; } = 1;
        public string? KeyWord { get; set; }
    }
}
