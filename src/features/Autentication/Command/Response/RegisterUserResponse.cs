using src.Models;

namespace src.features.Autentication.Command.Response
{
    public class RegisterUserResponse 
    {
        public string? Email { get; set; }
        public string? Name { get; set; }

        public static implicit operator RegisterUserResponse(User user)
        {
            return new RegisterUserResponse
            {
                Email = user.Email,
                Name = user.Name
            };
        }
    }
}