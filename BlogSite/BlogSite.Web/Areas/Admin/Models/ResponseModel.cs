using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models
{
    public class ResponseModel
    {
        public string Message { set; get; }
        public string Title { set; get; }
        public string IconCssClass { set; get; }
        public string StyleCssClass { set; get; }
        public string ToasterClass { get; set; }
        public ResponseModel() { }        
        public ResponseModel(string message,ResponseType type )
        {
            if (type == ResponseType.Success)
            {
                IconCssClass = "fa-check";
                StyleCssClass = "alert-success";
                Title = "success";
                ToasterClass = "success";
            }
            else if (type == ResponseType.Failure)
            {
                IconCssClass = "fa-ban";
                StyleCssClass = "alert-danger";
                Title = "Error !";
                ToasterClass = "Error";
            }
            Message = message;
        }
    }
}
