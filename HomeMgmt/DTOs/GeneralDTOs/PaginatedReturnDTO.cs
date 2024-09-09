namespace HomeMgmt.DTOs.GeneralDTOs
{
    public class PaginatedReturnDTO
    {
        public int Pages { get; set; }
        public dynamic Data { get; set; }
        public int TotalData { get; set; }

    }
}
