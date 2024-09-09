using HomeMgmt.Utils;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeMgmt.Models.UserModels
{
    public class BannedAccount : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public UserAccount UserAccount { get; set; }

        [ForeignKey("UserAccount")]
        public string UserAccoutId { get; set; } = null!;

        public string ReasonForBan { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}
