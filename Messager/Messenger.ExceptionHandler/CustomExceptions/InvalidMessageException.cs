namespace Messager.Messager.UnitOfWork.CustomExceptions;

public class InvalidMessageException : Exception
{
    public InvalidMessageException(string message) : base(message)
    {
        
    }   
}