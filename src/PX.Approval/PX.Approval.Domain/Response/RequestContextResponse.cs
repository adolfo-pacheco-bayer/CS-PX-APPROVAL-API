namespace PX.Approval.Domain.Response;

public class RequestContextResponse<T>
{
    public IEnumerable<RequestContextResponseError>? Errors { get; set; }

    public T? Data { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}

public class RequestContextResponseError
{
    public string? ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}
