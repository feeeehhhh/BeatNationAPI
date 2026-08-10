using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; } = string.Empty;

    }
}
