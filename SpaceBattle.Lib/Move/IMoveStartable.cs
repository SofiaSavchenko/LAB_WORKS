namespace SpaceBattle.Lib;

public interface IMoveStartable
{
    IUObject Obj
    {
        get;
    }
    Vector InitialVelocity
    {
        get;
    }
    
}

