using System;
using EhrlichWebAPI.Contracts;
using EhrlichWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using EhrlichWebAPI.Contracts;
using EhrlichWebAPI.Infrastructure;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace EhrlichWebAPI.Repositories
{
    
    public class CloudinaryRepository : BaseRepository<CloudinaryModel>, ICloudinaryRepository
    {

        public CloudinaryRepository() : base() { }
    }
   
}

