using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Family { get; set; } = "";
        public string Name { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class UserCreateDTO
    {
      
        public string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string? Patronymic { get; set; }
    }
}
