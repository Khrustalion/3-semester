namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station : ISectionRoute
{
    private readonly double _speedLimit;

    public Station(double speedLimit)
    {
        if (speedLimit < 0) throw new ArgumentException("Speed cannot be negative.");

        _speedLimit = speedLimit;
    }

    public PassingResult Passing(Train train, double precision)
    {
        if (train.Speed <= _speedLimit) return new PassingResult.Success();
        return new PassingResult.Failure();
    }
}
