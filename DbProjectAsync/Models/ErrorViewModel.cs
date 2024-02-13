namespace DbProjectAsync.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(int errorCode, string errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
