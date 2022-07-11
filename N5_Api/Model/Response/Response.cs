namespace N5.Api.Model.Response
{
    public class Response<T>
    {
        public Response(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public int State { get; set; }
        public string Message { get; set; }
    }
}
