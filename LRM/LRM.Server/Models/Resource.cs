using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LRM.Server.Models
{
    public class Resource
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }
}