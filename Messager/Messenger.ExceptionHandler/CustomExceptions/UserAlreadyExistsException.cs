namespace Messager.Messager.UnitOfWork.CustomExceptions;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException(string message) : base(message)
    {
        
    }
}