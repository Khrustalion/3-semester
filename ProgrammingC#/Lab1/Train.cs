namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    private readonly double _mass;
    private readonly double _maxForce;
    private double _acceleration;

    public double Speed { get; private set; }

    public Train(double mass, double maxForce)
    {
        if (mass <= 0) throw new ArgumentException("Mass must be positive");
        if (maxForce < 0) throw new ArgumentException("MaxForce cannot be negative");

        _mass = mass;
        _maxForce = maxForce;
        _acceleration = 0;
        Speed = 0;
    }

    public PassingResult TryApplyForce(double force)
    {
        if (force > _maxForce) return new PassingResult.Failure();

        _acceleration = force / _mass;

        return new PassingResult.Success();
    }

    public bool Standing()
    {
        return (Speed == 0 && _acceleration <= 0) || Speed < 0;
    }

    public void Iteration(double precision)
    {
        Speed += _acceleration * precision;
    }
}
