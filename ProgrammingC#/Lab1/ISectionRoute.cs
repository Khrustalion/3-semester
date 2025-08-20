namespace Itmo.ObjectOrientedProgramming.Lab1;

public interface ISectionRoute
{
    public PassingResult Passing(Train train, double precision);
}
