namespace JWTProject.Models
{
    public class ResponseModel<T>
    {
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
        public T? Result { get; set; }
    }
}
