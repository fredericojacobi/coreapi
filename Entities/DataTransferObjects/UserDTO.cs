using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public Guid BranchId { get; set; }

        public string Password { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public BranchDTO Branch { get; set; }

    }
}