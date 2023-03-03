namespace SocialMedia.Core.Responses
{
    public class BaseGenericResult<T>
    {
        public BaseGenericResult()
        {

        }
        public BaseGenericResult(T data, bool status, string message, int statusCode)
        {
            this.Data = data;
            this.Status = status;
            this.Message = message;
            this.StatusCode = statusCode;
        }

        public T Data { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string Description { get; set; }
    }
}
