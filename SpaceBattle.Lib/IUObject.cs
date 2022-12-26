namespace SpaceBattle.Lib;

public interface IUObject
{
    void set_Property(string key, object value);
    object get_Property(string key);
}

