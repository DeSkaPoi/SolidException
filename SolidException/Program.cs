using SolidException;
using SolidException.Handlers;
using SolidException.Logger;
using System.Collections.Concurrent;
using System.Windows.Input;

internal class Program
{
    static BlockingCollection<Action> commands = new BlockingCollection<Action>()
    {
        () => throw new NullReferenceException(),
        () => throw new OutOfMemoryException(),
        () => stop = true,
    };
    static bool stop = false;

    static ExceptionHandler _exceptionHandler = new ExceptionHandler(new NotFindExceptionHandle(new Logger()));
    private static void Main(string[] args)
    {
        _exceptionHandler.RegisterHandler(typeof(NullReferenceException), new NullReferenceExceptionHandle(new Logger()));


        while (!stop)
        {
            var cmd = commands.Take();
            try
            {
                cmd.Invoke();
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e.GetType(), cmd);
            }
        }
    }
}