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
        obj.Properties.ToList().ForEach(c => IoC.Resolve<ICommand>("SpaceBattle.SetupProperty", obj.Obj, c.Key, c.Value).Execute());
        var command = IoC.Resolve<ICommand>("SpaceBattle.Movement", obj.Obj);
        IoC.Resolve<ICommand>("SpaceBattle.SetupCommand", obj.Obj, "Movement", command).Execute();
        IoC.Resolve<ICommand>("SpaceBattle.QueuePush", command).Execute();
    }
}

