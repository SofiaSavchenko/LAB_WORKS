using Hwdtech;

namespace SpaceBattle.Lib;

public class StartMoveCommand : ICommand
{
    private IMoveStartable obj;
    public StartMoveCommand(IMoveStartable obj)
    {
        this.obj = obj;
    }

    public void Execute()
    {
        IoC.Resolve<ICommand>("SpaceBattle.SetupProperty", obj.Obj, "Velocity", obj.InitialVelocity).Execute();
        var command = IoC.Resolve<ICommand>("SpaceBattle.Move", obj.Obj);
        IoC.Resolve<ICommand>("SpaceBattle.SetupCommand", obj.Obj, "Move", command).Execute();
        var create_queue = IoC.Resolve<Queue<ICommand>>("SpaceBattle.Queue");
        IoC.Resolve<ICommand>("SpaceBattle.QueuePush", create_queue, command).Execute();

    }
}

