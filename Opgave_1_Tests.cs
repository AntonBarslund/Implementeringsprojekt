public static class Opgave_1_Tests
{
    public static void TestMultShift()
    {
        ulong result = Opgave_1.MultShift(102);

        Console.WriteLine($"a=102682031, l=34, x=102 => gives MultShift {result}");
    }
    public static void TestMultModPrime()
    {
        ulong result = Opgave_1.MultModPrime(102);
        Console.WriteLine($"a=102682031, l=34, x=102 => gives MultShift {result}");
    }


    public static void SpeedTestMultModPrime()
    {
        long[] checkpoints = new long[] { 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000 };

        for (int run = 1; run <= 5; run++)
        {
            ulong sum1 = 0;
            var sw1 = System.Diagnostics.Stopwatch.StartNew();
            long iter1 = 0;
            int cpIndex1 = 0;

            foreach (var item in Opgave_1.CreateStream(100_000_000, 5))
            {
                iter1++;
                sum1 += Opgave_1.MultModPrime(item.Item1);

                if (cpIndex1 < checkpoints.Length && iter1 == checkpoints[cpIndex1])
                {
                    Console.WriteLine($"Run {run}, MultShift: iterations={iter1}, elapsed={sw1.Elapsed.TotalMilliseconds:F3} ms");
                    System.IO.File.AppendAllText(
                        "mult_shift_times.csv",
                        $"{run},{iter1},{sw1.Elapsed.TotalMilliseconds:F3}\n"
                    );

                    cpIndex1++;
                }
            }

            sw1.Stop();
            Console.WriteLine($"Run {run}, MultShift sum: {sum1}  Total time: {sw1.Elapsed.TotalMilliseconds:F3} ms");
        }
    }
    public static void SpeedTestMultShift()
    {
        long[] checkpoints = new long[] { 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000 };

        for (int run = 1; run <= 5; run++)
        {
            ulong sum1 = 0;
            var sw1 = System.Diagnostics.Stopwatch.StartNew();
            long iter1 = 0;
            int cpIndex1 = 0;

            foreach (var item in Opgave_1.CreateStream(100_000_000, 5))
            {
                iter1++;
                sum1 += Opgave_1.MultShift(item.Item1);

                if (cpIndex1 < checkpoints.Length && iter1 == checkpoints[cpIndex1])
                {
                    Console.WriteLine($"Run {run}, MultShift: iterations={iter1}, elapsed={sw1.Elapsed.TotalMilliseconds:F3} ms");
                    System.IO.File.AppendAllText(
                        "mult_shift_times.csv",
                        $"{run},{iter1},{sw1.Elapsed.TotalMilliseconds:F3}\n"
                    );

                    cpIndex1++;
                }
            }

            sw1.Stop();
            Console.WriteLine($"Run {run}, MultShift sum: {sum1}  Total time: {sw1.Elapsed.TotalMilliseconds:F3} ms");
        }
    }
}
