using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningResourceManager.Models
{
    public class Resources
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Keywords { get; set; }
    }
}