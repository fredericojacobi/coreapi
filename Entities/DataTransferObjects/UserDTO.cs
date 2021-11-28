using Generic.Models;

namespace Entities.DataTransferObjects
{
    public class UserDTO : ObjectBase
    {
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
    }
}