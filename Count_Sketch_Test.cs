public static class Count_Sketch_Test {

    private static IEnumerable<Tuple<ulong, int>> CreateStream()
    {
        // Create an empty Entry where you have (x, delta) pairs
        yield return new Tuple<ulong, int>(1, 5);
        yield return new Tuple<ulong, int>(2, 3);
        yield return new Tuple<ulong, int>(1, 4);
        yield return new Tuple<ulong, int>(3, 2);
        yield return new Tuple<ulong, int>(3, 2);
        yield return new Tuple<ulong, int>(3, 2);
        yield return new Tuple<ulong, int>(3, 2);
        yield return new Tuple<ulong, int>(3, 2);
        yield return new Tuple<ulong, int>(3, 2);
    }

    public static void TestSquaresum()
    {
        int l = 8;
        
        Hashtable_with_Chaining.Init(l, Hashfunctions.MultShift);
        ulong ExactS = Hashtable_with_Chaining.squaresum(Count_Sketch_Test.CreateStream());

        Console.WriteLine($"Exact S= {ExactS}");

        long sum = Count_Sketch.est_square_sum(Count_Sketch_Test.CreateStream(),0);
        Console.WriteLine($"approximate S= {sum}");

    }

    public static void TestSquaresumApproximation()
    {
        int l = 8;
        int n = 1_000_000;
        // create stream 
        List<Tuple<ulong, int>> stream = Hashfunctions.CreateStream(n, l).ToList();

        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        Hashtable_with_Chaining.Init(l, Hashfunctions.MultShift);
        ulong ExactS = Hashtable_with_Chaining.squaresum(stream);
        long exactRuntime = stopwatch.ElapsedMilliseconds;
        stopwatch.Stop();
        Console.WriteLine($"Exact S= {ExactS},  Runtime: {stopwatch.ElapsedMilliseconds}ms");


        
        List<Tuple<long, long>> results = new List<Tuple<long, long>>();

        // Run this 100 times
        for (ulong i = 0; i < 100; i++)
        {
            var stopwatchLoop = System.Diagnostics.Stopwatch.StartNew();
            long sum = Count_Sketch.est_square_sum(stream, i);
            stopwatchLoop.Stop();
            Console.WriteLine($"Done i={i}, Runtime: {stopwatchLoop.ElapsedMilliseconds}ms");

            results.Add(new Tuple<long, long>(sum, stopwatchLoop.ElapsedMilliseconds));
        }
        
        // Write to CSV file
        using (StreamWriter writer = new StreamWriter("results_0_5.csv"))
        {
            writer.WriteLine($"{ExactS},{exactRuntime}");
            foreach (var result in results)
            {
                writer.WriteLine($"{result.Item1},{result.Item2}");
            }
        }
        
        Console.WriteLine($"Results written to results_0_5.csv");
    }

}

