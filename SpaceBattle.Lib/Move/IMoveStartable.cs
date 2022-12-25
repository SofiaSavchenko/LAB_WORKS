namespace SpaceBattle.Lib;

public interface IMoveStartable
{
    IUObject Obj
    {
        get;
    }

    IDictionary<string, object> Properties
    {
        get;
    }
}

