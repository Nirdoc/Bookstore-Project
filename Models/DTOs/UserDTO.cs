using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfJoing { get; set; }
        
        public RoleDTO Role { get; set; }
        public UserDetailsDTO UserDetails { get; set; }
    }
}
