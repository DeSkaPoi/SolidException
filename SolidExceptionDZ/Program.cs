using SolidExceptionDZ.Logger;
using SolidExceptionDZ;
using System.Collections.Concurrent;
using SolidExceptionDZ.Abstraction;
using SolidExceptionDZ.Commands;

internal class Program
{
    private static void Main(string[] args)
    {
        bool stop = false;
        BlockingCollection<ICommand> commands = new BlockingCollection<ICommand>()
        {
            new Command(() => throw new NullReferenceException())
        };


        ICommand logCommand = new LogWarningCommand(null, new Logger());
        ICommand repeaterExccept = new RepeaterCommand(null, commands);
        ICommand repeaterLog = new RepeaterCommand(logCommand, commands);
        ICommand macro = new MacroCommand(new List<ICommand>() { repeaterExccept, repeaterLog });
        ExceptionHandler _exceptionHandler = new ExceptionHandler(macro);

        _exceptionHandler.RegisterHandler(typeof(NullReferenceException), logCommand);


        while (!stop)
        {
            var cmd = commands.Take();
            try
            {
                cmd.Invoke();
            }
            catch (Exception e)
            {
                var tmp = repeaterExccept as IInject<ICommand>;
                tmp.Inject = cmd;
                _exceptionHandler.Handle(e);
            }
        }
    }
}