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
        int n = 100_000;

        List<Tuple<ulong, int>> stream = Hashfunctions.CreateStream(n, l).ToList();
        
        Hashtable_with_Chaining.Init(l, Hashfunctions.MultShift);
        ulong ExactS = Hashtable_with_Chaining.squaresum(stream);

        Console.WriteLine($"Exact S= {ExactS}");
        
        List<long> results = new List<long>();
        // Run this 100 times
        for (ulong i = 0; i < 100; i++)
        {
            long sum = Count_Sketch.est_square_sum(stream,i);
            Console.WriteLine($"Done i={i}");

            results.Add(sum);
        }
        
        // Write to CSV file
        using (StreamWriter writer = new StreamWriter("results.csv"))
        {
            writer.WriteLine(ExactS);
            foreach (long result in results)
            {
                writer.WriteLine(result);
            }
        }
        
        Console.WriteLine($"Results written to results.csv");
    }

}

