using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class EletronicPointHistoryDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        
        public Guid PointId { get; set; }
        
        public DateTime Date { get; set; }
        
        public UserDTO User { get; set; }

        public PointDTO Point { get; set; }
        
    }
}