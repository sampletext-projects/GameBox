using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace GameBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : Controller
    {
        [HttpPost]
        public ActionResult Upload()
        {
            // получаем имя файла
            // var fileName = Path.GetFileName(file.FileName);

            var file = Request.Form.Files["file"];
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var guid = Guid.NewGuid();
                var filename = guid + file.FileName.Substring(file.FileName.LastIndexOf('.'));
                var fullDirName = Path.Combine(Startup.WWWRootPath, "images");

                if (!Directory.Exists(fullDirName))
                {
                    Directory.CreateDirectory(fullDirName);
                }

                FileStream fs =
                    new FileStream(
                        Path.Combine(
                            Startup.WWWRootPath,
                            "images", filename),
                        FileMode.Create);
                ms.CopyTo(fs);
                fs.Close();
                return Ok(filename);
            }
        }
    }
}