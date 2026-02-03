using System.Diagnostics;

public class TimeHelper
{
    public static (double, T) Time<T>(Func<T> executeAlgorithm, int times)
    {
        var sw = Stopwatch.StartNew();
        T result = default;
        for (var i = 0; i < times; ++i)
        {
            result = executeAlgorithm(); // Calls the action passed in to this method
        }

        sw.Stop();
        return ((sw.Elapsed.TotalMilliseconds / times), result);
    }
}