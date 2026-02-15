using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string NameSurname { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
