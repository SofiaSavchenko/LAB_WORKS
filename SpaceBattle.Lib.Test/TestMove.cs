namespace SpaceBattle.Lib.Test;
using Moq;
public class MoveCommandTests
{
    [Fact]
    public void TestPositiveMove()
    {
        Mock<IMovable> movableMock = new Mock<IMovable>();
        movableMock.SetupProperty<Vector>(m => m.Position, new Vector(12, 5));
        movableMock.SetupGet<Vector>(m => m.Velocity).Returns(new Vector(-7, 3));

        ICommand c = new MoveCommand(movableMock.Object);
        c.Execute();

        Assert.Equal(new Vector(5, 8), movableMock.Object.Position);
    }

    [Fact]
    public void TestImpossibleGetPosition()
    {
        Mock<IMovable> movableMock = new Mock<IMovable>();
        movableMock.SetupGet<Vector>(m => m.Position).Throws<Exception>();
        movableMock.SetupGet<Vector>(m => m.Velocity).Returns(new Vector(-7, 3));

        ICommand c = new MoveCommand(movableMock.Object);
        Assert.Throws<Exception>(() => c.Execute());
    }

    [Fact]
    public void TestImpossibleGetVelocity()
    {
        Mock<IMovable> movableMock = new Mock<IMovable>();
        movableMock.SetupProperty<Vector>(m => m.Position, new Vector(12, 5));
        movableMock.SetupGet<Vector>(m => m.Velocity).Throws<Exception>();

        ICommand c = new MoveCommand(movableMock.Object);
        Assert.Throws<Exception>(() => c.Execute());
    }

    [Fact]
    public void TestImpossibleSetPosition()
    {
        Mock<IMovable> movableMock = new Mock<IMovable>();
        movableMock.SetupProperty(m => m.Position, new Vector(12, 5));
        movableMock.SetupGet<Vector>(m => m.Velocity).Returns(new Vector(-7, 3));
        movableMock.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<Exception>();
        
        ICommand c = new MoveCommand(movableMock.Object);
        Assert.Throws<Exception>(() => c.Execute());
    }
}