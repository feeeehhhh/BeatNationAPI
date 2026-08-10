using src.features.Autentication.Command.Response;
using src.Models;
using MediatR;

namespace src.features.Autentication.Command.Request
{
    public class RegisterUserRequest : IRequest<RegisterUserResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }

        public string? UserName { get; set; }
        

         public static implicit operator src.domain.modelsUser(RegisterUserRequest registerRequestDto)
        {
            return new src.domain.modelsUser
            {
                Email = registerRequestDto.Email,
                Name = registerRequestDto.Name,
                UserName = registerRequestDto.UserName,
                PhoneNumber = registerRequestDto.PhoneNumber
            };
        }
    } 
        
}