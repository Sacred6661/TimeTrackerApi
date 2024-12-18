namespace TimeTrackerApi.Models
{
    public class ResponseModel<T>
    {
        public bool IsError { get; set; } = false;
        public string ErrorMessage { get; set; } = "";
        public T Data { get; set; }
    }
}
