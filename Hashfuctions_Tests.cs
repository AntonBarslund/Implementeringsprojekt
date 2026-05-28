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

public static void TestDifferentN()
{
    int l = 8;
    List<int> ns = [10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000];
    
    string outputPath = "/Users/antonbarslund/Documents/GitHub/Implementeringsprojekt1/mult_shift_times.csv";
    
    using (StreamWriter writer = new StreamWriter(outputPath))
    {
        for (int run = 0; run < 5; run++)
        {
            foreach (int n in ns)
            {
                ulong sum = 0;
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                foreach (Tuple<ulong, int> item in Hashfunctions.CreateStream(n, l))
                {
                    sum += Hashfunctions.MultShift(item.Item1, l);
                }

                stopwatch.Stop();
                
                int seconds = (int)(stopwatch.Elapsed.TotalMilliseconds / 1000);
                int millis = (int)(stopwatch.Elapsed.TotalMilliseconds % 1000);
                
                writer.WriteLine($"{n},{seconds},{millis}");
            }
        }
    }
    
    Console.WriteLine($"Results saved to {outputPath}");

    string outputPath2 = "/Users/antonbarslund/Documents/GitHub/Implementeringsprojekt1/mult_mod_prime_times.csv";
    
    using (StreamWriter writer = new StreamWriter(outputPath2))
    {
        for (int run = 0; run < 5; run++)
        {
            foreach (int n in ns)
            {
                ulong sum = 0;
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                foreach (Tuple<ulong, int> item in Hashfunctions.CreateStream(n, l))
                {
                    sum += Hashfunctions.MultModPrime(item.Item1, l);
                }

                stopwatch.Stop();
                
                int seconds = (int)(stopwatch.Elapsed.TotalMilliseconds / 1000);
                int millis = (int)(stopwatch.Elapsed.TotalMilliseconds % 1000);
                
                writer.WriteLine($"{n},{seconds},{millis}");
            }
        }
    }
    
    Console.WriteLine($"Results saved to {outputPath2}");
}
    
}
