using System;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class EletronicPointHistoryDTO
    {
        public Guid Id { get; set; }
        
        public UserDTO User { get; set; }

        public PointDTO Point { get; set; }
    }
}