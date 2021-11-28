using System;
using Entities.Models;
using Generic.Models;

namespace Entities.DataTransferObjects
{
    public class EletronicPointHistoryDTO : ObjectBase
    {
        public Guid UserId { get; set; }
        
        public Guid LocationId { get; set; }
        
        public UserDTO User { get; set; }

        public Location Location { get; set; }
    }
}