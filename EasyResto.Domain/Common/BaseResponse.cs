namespace EasyResto.Domain.Common
{
    public class BaseResponse<T>
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public List<String> Errors { get; set; }
        public T Data { get; set; }

        public BaseResponse()
        {
            Title = string.Empty;
            Status = 200;
            Message = string.Empty;
            Errors = new List<string>();
        }
    }
}
