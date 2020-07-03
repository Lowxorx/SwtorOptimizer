namespace SwtorOptimizer.Models
{
    public class ResultObject<T>
    {
        public T Data { get; set; }
        public string Message{ get; set; }
        public int StatusCode { get; set; }
    }
}