namespace Itmo.ObjectOrientedProgramming.Lab1;

public class MagneticPath : ISectionRoute
{
    private readonly double _distance;

    public MagneticPath(double distance)
    {
        if (distance < 0) throw new ArgumentException("Distance cannot be negative");

        _distance = distance;
    }

    public PassingResult Passing(Train train, double precision)
    {
        if (precision < 0) throw new ArgumentException("Precision cannot be negative");
        if (train.TryApplyForce(0) is PassingResult.Failure) return new PassingResult.Failure();

        double distance = _distance;

        while (distance > 0)
        {
            if (train.Standing()) return new PassingResult.Failure();

            train.Iteration(precision);

            distance -= train.Speed * precision;
        }

        return new PassingResult.Success();
    }
}
