using I_formFile.Models;
using Microsoft.AspNetCore.Mvc;

namespace I_formFile.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Index()
        {
            SingleFileUpload model = new SingleFileUpload();

            return View(model);
        }


        public IActionResult SingleFileSave(SingleFileUpload model)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FileSave");
            //create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            //get file extension
            model.FileName = Guid.NewGuid().ToString()+model.File.FileName;

            string fileNameWaithPath=Path.Combine(path,model.FileName);

            using (var stream = new FileStream(fileNameWaithPath, FileMode.Create))
            {
                model.File.CopyTo(stream);
            }
            model.IsSuccess=true;
            model.Message = "File Uploaded SuccessFully !";
                return View("Index",model);
        }
    }
}
