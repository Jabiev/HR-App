namespace HRproject.Business.Exceptions;

internal class NotRemovedbyContainSomeItemsException : Exception
{
    public NotRemovedbyContainSomeItemsException(string? message) : base(message)
    {
    }
}
