using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeatNationAPI.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;

    }
}
