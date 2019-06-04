using Abc.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Auth.Interfaces
{
    public interface IJwtGenerator
    {
        Task<object> GenerateJwt(User user);
    }

}
