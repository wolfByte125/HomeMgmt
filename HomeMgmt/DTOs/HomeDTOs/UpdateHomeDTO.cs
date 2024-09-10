namespace HomeMgmt.DTOs.HomeDTOs
{
    public class UpdateHomeDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<HouseholdMemberDTO> HouseholdMembers { get; set; } = [];
    }
}
