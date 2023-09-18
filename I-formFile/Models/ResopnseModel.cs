namespace I_formFile.Models
{
    public class ResopnseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsResponse { get; set; }


    }


    public class SingleFileUpload: ResopnseModel //here we are inheriting the response model 
    {
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }


    public class MultipleFileUpload : ResopnseModel   //here we are inheriting the response model 
    {
       //To upload multiple files we have to make a list in iformfile file Upload
        public List<IFormFile> Files { get; set; }
    }

}
