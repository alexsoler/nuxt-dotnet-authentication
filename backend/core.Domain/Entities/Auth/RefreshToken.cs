using System;
using System.ComponentModel.DataAnnotations;
using core.Domain.Entities.User;

namespace core.Domain.Entities.Auth
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public Guid Value { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }

        public int ClientId { get; set; }
        
        public String UserId { get; set; }
        public ApplicationUser User { get; set; }
    }    
}