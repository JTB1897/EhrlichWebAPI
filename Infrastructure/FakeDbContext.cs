using System;
using System.Collections.Generic;
using System.Linq;
using EhrlichWebAPI.Models;

namespace EhrlichWebAPI.Infrastructure
{
    public class FakeDbContext
    {
        public FakeDbContext()
        {
            Users = new List<User>() {
                new User{ Id = 1, Email = "admin.com", Password = "admin" }
            };
            
            CloudinaryModels = new List<CloudinaryModel>();
        }

        public List<User> Users { get; set; }
       
        public List<CloudinaryModel> CloudinaryModels { get; set; }

        public List<T> GetTable<T>()
        {
            return GetType()
                .GetProperties()
                .FirstOrDefault(p => p.GetValue(this, null) is List<T>)
                ?.GetValue(this, null) as List<T>;
        }
    }
}
