namespace HRproject.Business.Exceptions;

public class ValueNullorEmptyException : Exception
{
    public ValueNullorEmptyException(string? message) : base(message)
    {
    }
}
