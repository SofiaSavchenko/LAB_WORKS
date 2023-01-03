using SpaceBattle.Lib;

public class GetPropertyStrategy : IStrategy
{
    public object ExecuteStrategy(params object[] args)
    {
        var obj = (IUObject)args[0];
        var property = (string)args[1];
        return obj.get_Property(property);
    }
}

