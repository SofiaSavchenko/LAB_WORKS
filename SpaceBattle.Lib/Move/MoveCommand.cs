namespace SpaceBattle.Lib;

public class MoveCommand: ICommand
{
    public IMovable obj;
    public MoveCommand(IMovable obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {
        obj.Position += obj.Velocity;
    }
}

