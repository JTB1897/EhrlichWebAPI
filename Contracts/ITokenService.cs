using System;
using EhrlichWebAPI.Models;

namespace EhrlichWebAPI.Contracts
{
    public interface ITokenService
    {
        string GenererateToken(User user);
        bool IsValid(string token);
      
    }
}
