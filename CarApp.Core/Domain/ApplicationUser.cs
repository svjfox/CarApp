using Microsoft.AspNetCore.Identity;

namespace CarApp.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        // Дополнительные свойства пользователя (если нужно)
        public string FullName { get; set; }
    }
}