using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITokenRepository
    {
        string CreateJwtToke(IdentityUser user,List<string> roles);
    }
}
