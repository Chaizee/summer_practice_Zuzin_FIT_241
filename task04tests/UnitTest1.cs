using Xunit;
using task04;
namespace task04tests;

public class SpaceshipTests
{
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        var cruiser = new Cruiser();
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
    }

    [Fact]
    public void Fighter_ShouldHaveCorrectStats()
    {
        var fighter = new Fighter();
        Assert.Equal(100, fighter.Speed);
        Assert.Equal(50, fighter.FirePower);
    }

    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.Speed > cruiser.Speed);
    }

    [Fact]
    public void Cruiser_ShouldBeStrongerThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.FirePower < cruiser.FirePower);
    }
    
    [Fact]
    public void CruiserAndFighter_ShouldBeMoveForwardCorrect() {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        fighter.MoveForward();
        cruiser.MoveForward();
        Assert.Equal(50, cruiser.Own_X);
        Assert.Equal(0, cruiser.Own_Y);
        Assert.Equal(100, fighter.Own_X);
        Assert.Equal(0, fighter.Own_Y);
    }

    [Fact] 
    public void CruiserAndFighter_ShouldBeRotateCorrect() {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        cruiser.Rotate(90);
        Assert.Equal(90, cruiser.Own_Angle);
        fighter.Rotate(100);
        Assert.Equal(100, fighter.Own_Angle);
    }

    [Fact]
    public void CruiserAndFighter_ShouldBeFireCorrect() {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        fighter.Fire();
        Assert.True(fighter.Fired);
        cruiser.Fire();
        Assert.True(cruiser.Fired);
    }
}
