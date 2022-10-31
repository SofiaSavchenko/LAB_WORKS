namespace SpaceBattle.Lib;
public class Vector
{
    public int[] Vec;
    public int Size;
    public Vector(params int[] array)
    {
        Size = array.Length;
        Vec = new int[Size];

        for (int i = 0; i < Size; i++)
        {
            Vec[i] = array[i];
        }
    }
    public override string ToString()
    {
        string it_is = "Vector(";
        for (int i = 0; i < Size; i++)
        {
            if (i == Size - 1)
            {
                it_is += Vec[i];
            }
            else
            {
                it_is += Vec[i] + ", ";
            }
        }
        it_is += ")";
        return it_is;
    }
    public int this[int ind]
    {
        get 
        { 
            return Vec[ind]; 
        }
    }
    public static Vector operator +(Vector a, Vector b)
    {
        if (a.Size != b.Size)
        {
            throw new ArgumentException();
        }
        else
        {
            int[] mass = new int[a.Size];

            for (int i = 0; i < a.Size; i++)
            {
                mass[i] = a[i] + b[i];
            }
            return new Vector(mass);
        }
    }
    public static Vector operator -(Vector a, Vector b)
    {
        if (a.Size != b.Size)
        {
            throw new ArgumentException();
        }
        else
        {
            int[] mass = new int[a.Size];

            for (int i = 0; i < a.Size; i++)
            {
                mass[i] = a[i] - b[i];
            }
            return new Vector(mass);
        }
    }
    public static Vector operator *(int a, Vector b)
    {
        int[] mass = new int[b.Size];
        for(int i = 0; i < b.Size; i++)
        {
            mass[i] = a * b[i];
        }
        return new Vector(mass);
    }
    public static bool operator ==(Vector a, Vector b)
    {
        if (a.Size != b.Size)
        {
            return false;
        }
        for (int i = 0; i < a.Size; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }
    public static bool operator !=(Vector a, Vector b)
    {
        if (a == b)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    public override bool Equals(object? obj)
    {
        return obj is Vector;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Vec);
    }
    public static bool operator <(Vector a, Vector b)
    {
        if (a.Size > b.Size)
        {
            return false;
        }
        for (int i = 0; i < a.Size; i++)
        {
            if (a[i] > b[i])
            {
                return false;
            }
        }
        return true;
    }
    public static bool operator >(Vector a, Vector b)
    {
        if (a.Size < b.Size)
        {
            return false;
        }
        for (int i = 0; i < a.Size; i++)
        {
            if (a[i] < b[i])
            {
                return false;
            }
        }
        return true;
    }
}