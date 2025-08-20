namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    private readonly double _precision;
    private readonly Train _train;
    private readonly List<ISectionRoute> _sectionsRoads;
    private readonly double _finalSpeedLimit;

    public Route(Train train, double precision, double finalSpeedLimit)
    {
        _precision = precision;
        _train = train;
        _sectionsRoads = new List<ISectionRoute>();
        _finalSpeedLimit = finalSpeedLimit;
    }

    public void AddSection(ISectionRoute section)
    {
        _sectionsRoads.Add(section);
    }

    public bool Passing()
    {
        foreach (ISectionRoute section in _sectionsRoads)
        {
            if (section.Passing(_train, _precision) is PassingResult.Failure) return false;
        }

        return _train.Speed <= _finalSpeedLimit;
    }
}
