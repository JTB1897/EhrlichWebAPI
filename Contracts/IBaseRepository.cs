using System;
using System.Collections.Generic;
using EhrlichWebAPI.Models;

namespace EhrlichWebAPI.Contracts
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetOne(int id);
        void Add(T user);
        void Update(T user);
        void Delete(int id);
    }
}
