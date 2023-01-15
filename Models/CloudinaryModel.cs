using System;
using System.ComponentModel.DataAnnotations;
using EhrlichWebAPI.Contracts;
using System;

namespace EhrlichWebAPI.Models
{
    public class CloudinaryModel: IBaseModel
    {
        public int Id { get; set; }
        
        public string Url { get; set; }

        public string publicId { get; set; }
    }
}
