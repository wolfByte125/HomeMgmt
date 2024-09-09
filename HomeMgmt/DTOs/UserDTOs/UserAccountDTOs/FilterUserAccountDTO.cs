namespace HomeMgmt.DTOs.UserDTOs.UserAccountDTOs
{
    public class FilterUserAccountDTO
    {
        public string? Status { get; set; }

        public int? UserRoleId { get; set; }

        public string? Gender { get; set; }

        public string? RoleName { get; set; } = string.Empty;
    }
}
