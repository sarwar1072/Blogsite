using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Web.Areas.Admin.Models
{
   public class MenuChildItem
    {
        public string?  Title { get; set; }
        public string? Url { get; set; }
        public string? Active { get; set; }
    }
}
