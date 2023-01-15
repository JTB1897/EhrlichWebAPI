using System;
using System.Collections.Generic;
using EhrlichWebAPI.Models;

namespace EhrlichWebAPI.Contracts
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public string Login(string email, string password);
    }
}
