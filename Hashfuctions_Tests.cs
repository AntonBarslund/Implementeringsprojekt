public static class Hashing_Tests
{
    public static void TestRunningTimes()
    {
        int n = 1_000_000;
        int l = 8;

        TestRunningTime("MultShift", n, l, Hashfunctions.MultShift);
        TestRunningTime("MultModPrime", n, l, Hashfunctions.MultModPrime);
    }

    private static void TestRunningTime(string name, int n, int l, Func<ulong, int, ulong> hashFunction)
    {
        ulong sum = 0;
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        foreach (Tuple<ulong, int> item in Hashfunctions.CreateStream(n, l))
        {
            sum += hashFunction(item.Item1, l);
        }

        stopwatch.Stop();

        Console.WriteLine($"{name}: n={n}, sum={sum}, time={stopwatch.Elapsed.TotalMilliseconds:F2} ms");
    }
}
