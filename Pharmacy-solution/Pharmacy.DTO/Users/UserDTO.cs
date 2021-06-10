using System;

namespace Pharmacy.DTO.Users
{
    public class UserDTO : BaseUserDTO
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}