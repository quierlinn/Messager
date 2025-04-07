namespace Messager.Messager.UnitOfWork.CustomExceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
        
    }
}