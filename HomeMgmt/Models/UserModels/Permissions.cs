using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomeMgmt.Models.UserModels
{
    public class Permissions
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
    }
}
