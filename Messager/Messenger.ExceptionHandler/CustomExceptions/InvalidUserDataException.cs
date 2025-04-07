namespace Messager.Messager.UnitOfWork.CustomExceptions;

public class InvalidUserDataException : Exception
{
    public InvalidUserDataException(string message) : base(message)
    {
        
    }
}