namespace I_formFile.Models
{
    public class ResopnseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsResponse { get; set; }


    }


    public class SingleFileUpload: ResopnseModel
    {
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
