namespace Guru.Service.Helpers;

public class Response<T>
{
    public long StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
