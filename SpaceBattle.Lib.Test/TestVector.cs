namespace SpaceBattle.Lib.Test;
public class TestVector
{
    [Fact]
    public void OutString()
    {
        Vector vec = new Vector(1, 1);
        string str_vec = "Vector(1, 1)";
       
        Assert.Equal(str_vec, vec.ToString());
    }

    [Fact]
    public void OutIndex()
    {
        Vector vec = new Vector(1, 1);
        int ind = 1;
       
        Assert.Equal(ind, vec[0]);
    }

    [Fact]
    public void PositiveAddVector()
    {
        Vector a = new Vector(1, 1);
        Vector b = new Vector(2, 2);
        Vector res = new Vector(3, 3);

        Assert.Equal(res, a + b);
    }

    [Fact]
    public void NegativeAddVector()
    {
        Vector a = new Vector(1, 1, 1);
        Vector b = new Vector(2, 2);
        
        Assert.Throws<ArgumentException>(() => a + b);
    }

    [Fact]
    public void PositiveSubVector()
    {
        Vector a = new Vector(2, 2);
        Vector b = new Vector(1, 1);
        Vector res = new Vector(1, 1);

        Assert.Equal(res, a - b);
    }

    [Fact]
    public void NegativeSubVector()
    {
        Vector a = new Vector(2, 2, 2);
        Vector b = new Vector(1, 1);

        Assert.Throws<ArgumentException>(() => a - b);
    }

    [Fact]
    public void PositiveEqualVector()
    {
        Vector a = new Vector(1, 1);
        Vector b = new Vector(1, 1);

        Assert.True(a == b);
    }

    [Fact]
    public void NegativeEqualVector()
    {
        Vector a = new Vector(1, 1, 1);
        Vector b = new Vector(1, 1);

        Assert.False(a == b);
    }

    [Fact]
    public void PositiveInequalVector()
    {
        Vector a = new Vector(1, 1, 1);
        Vector b = new Vector(1, 1);

        Assert.True(a != b);
    }

    [Fact]
    public void NegativeInequalVector()
    {
        Vector a = new Vector(1, 1);
        Vector b = new Vector(1, 1);

        Assert.False(a != b);
    }

    [Fact]
    public void NegativeEquals()
    {
        Vector a = new Vector(1, 1);
        int b = 3;

        Assert.False(a.Equals(b));
    }

    [Fact]
    public void NegativeGetHashCode()
    {
        Vector a = new Vector(1, 2);
        Vector b = new Vector(2, 1);

        Assert.True(a.GetHashCode() != b.GetHashCode());
    }
}

