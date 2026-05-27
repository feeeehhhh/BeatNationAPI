using BeatNationAPI.Application.Autentication.Command.Response;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Autentication.Command.Request
{
    public class RegisterUserRequest : IRequest<RegisterUserResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Name { get; set; }

        public string? UserName { get; set; }
        

         public static implicit operator BeatNationAPI.Models.User(RegisterUserRequest registerRequestDto)
        {
            return new BeatNationAPI.Models.User
            {
                Email = registerRequestDto.Email,
                Name = registerRequestDto.Name,
                UserName = registerRequestDto.UserName,
                PhoneNumber = registerRequestDto.PhoneNumber
            };
        }
    } 
        
}