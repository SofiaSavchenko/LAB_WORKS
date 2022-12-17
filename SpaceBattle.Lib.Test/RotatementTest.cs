using Moq;

namespace SpaceBattle.Lib.Test;
public class RotatementTest{
    [Fact]
    public void ChangeAngleTest(){
        var rotateTest = new Mock<IRotatable>();
        rotateTest.SetupProperty(mo => mo.Angle, 45);
        rotateTest.SetupGet(mo => mo.AngleVelocity).Returns(90);
        var rotateCommand = new RotateCommand(rotateTest.Object);
        rotateCommand.Execute();
        rotateTest.VerifySet(mo => mo.Angle = 135);
    }

    [Fact]
    public void ImmutableAngleTest(){
        var rotateTest = new Mock<IRotatable>();
        rotateTest.SetupProperty(mo => mo.Angle, 45);
        rotateTest.SetupGet(mo => mo.AngleVelocity).Returns(90);
        rotateTest.SetupSet(mo => mo.Angle = It.IsAny<int>()).Throws<Exception>();   
        RotateCommand rotateCommand = new RotateCommand(rotateTest.Object);
        Assert.Throws<Exception>(() => rotateCommand.Execute());
    }

    [Fact]
    public void UnreadableAngleVelocityTest(){
        var rotateTest = new Mock<IRotatable>();
        rotateTest.SetupProperty(mo => mo.Angle, 45);
        rotateTest.SetupGet(mo => mo.AngleVelocity).Throws<Exception>();
        RotateCommand rotateCommand = new RotateCommand(rotateTest.Object);
        Assert.Throws<Exception>(() => rotateCommand.Execute());
    }

    [Fact]
    public void UnreadableAngleTest(){
        var rotateTest = new Mock<IRotatable>();
        rotateTest.SetupGet(mo => mo.Angle).Throws<Exception>();
        rotateTest.SetupGet(mo => mo.AngleVelocity).Returns(90);
        RotateCommand rotateCommand = new RotateCommand(rotateTest.Object);
        Assert.Throws<Exception>(() => rotateCommand.Execute());
    }
}
