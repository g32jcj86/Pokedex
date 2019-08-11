using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Pokedex.Controllers
{
    public class fileController : ApiController
    {
        [HttpPost]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                string num = HttpContext.Current.Request.Form["num"].ToString();

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    //var fileSavePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/img"), httpPostedFile.FileName);
                    var fileSavePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/img"), num + ".png");

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }
    }
}
