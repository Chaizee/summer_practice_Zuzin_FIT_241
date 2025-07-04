using System;
namespace task04;

public interface ISpaceship
{
    void MoveForward();
    void Rotate(int angle);
    void Fire();
    int Speed { get; }
    int FirePower { get; }
}

public class Cruiser : ISpaceship 
{
    public double Own_X;
    public double Own_Y;
    public int Own_Angle;
    public bool Fired;

    public int Speed => 50;
    public int FirePower => 100;

    public Cruiser(double x = 0, double y = 0, int ang = 0, bool fired = false) {
        Own_X = x;
        Own_Y = y;
        Own_Angle = ang;
        Fired = fired;
    }

    public void MoveForward() {

        double New_X = Speed * Math.Cos((Own_Angle * Math.PI) / 180.0);
        double New_Y = Speed * Math.Sin((Own_Angle * Math.PI)/ 180.0);

        Own_X = Math.Round(New_X + Own_X, 2);
        Own_Y = Math.Round(New_Y + Own_Y, 2);
    }

    public void Rotate(int angle) {
        Own_Angle = (Own_Angle + angle) % 360;
    }

    public void Fire() {
        Fired = true;
    }
}

public class Fighter : ISpaceship 
{
    public double Own_X;
    public double Own_Y;
    public int Own_Angle;
    public bool Fired;

    public int Speed => 100;
    public int FirePower => 50;

    public Fighter(double x = 0, double y = 0, int ang = 0, bool fired = false) {
        Own_X = x;
        Own_Y = y;
        Own_Angle = ang;
        Fired = fired;
    }

    public void MoveForward() {

        double New_X = Speed * Math.Cos((Own_Angle * Math.PI) / 180.0);
        double New_Y = Speed * Math.Sin((Own_Angle * Math.PI)/ 180.0);

        Own_X = Math.Round(New_X + Own_X, 2);
        Own_Y = Math.Round(New_Y + Own_Y, 2);
    }

    public void Rotate(int angle) {
        Own_Angle = (Own_Angle + angle ) % 360;
    }   

    public void Fire() {
        Fired = true;
    }
}