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
       
        
        public IActionResult MultiplFileUpload()
        {
            MultipleFileUpload model = new MultipleFileUpload();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MultipleFileSave(MultipleFileUpload model)

        {

            if(model.Files.Count>0)
            {
                foreach(var file in model.Files) {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/MultiFileSave");
                    //create folder if not exist
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);

                    }
                    //get file extension
                 string filename= Guid.NewGuid().ToString() + file.FileName;

                    string fileNameWaithPath = Path.Combine(path, filename);

                    using (var stream = new FileStream(fileNameWaithPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                model.IsSuccess = true;
                model.Message = "File Uploaded SuccessFully !";

            }
            else
            {

                model.IsSuccess = false;
                model.Message = "File Not Uploaded  !";
            }
            
           
         
            return View("MultiplFileUpload", model);

        }



    }

}
