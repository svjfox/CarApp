using Microsoft.AspNetCore.Identity;

namespace CarApp.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        // Дополнительное свойство для полного имени пользователя
        public string FullName { get; set; }
    }
}
