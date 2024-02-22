namespace apiwc.utils;

public class Message(string message, int code)
{
    private readonly string _message = message;

    private readonly int _code = code;
    
    public object Generate()
    {
        return new
        {
            message = this._message,
            code = this._code
        };
    }
}