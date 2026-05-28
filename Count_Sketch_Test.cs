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

        long sum = Count_Sketch.est_square_sum(Count_Sketch_Test.CreateStream());
        Console.WriteLine($"approximate S= {sum}");

    }

        public static void TestSquaresumApproximation()
    {
        int l = 8;
        int n = 10_000_000;
        
        Hashtable_with_Chaining.Init(l, Hashfunctions.MultShift);
        ulong ExactS = Hashtable_with_Chaining.squaresum(Hashfunctions.CreateStream(n,l));

        Console.WriteLine($"Exact S= {ExactS}");


        // Run this 100 times
        long sum = Count_Sketch.est_square_sum(Hashfunctions.CreateStream(n,l));
        Console.WriteLine($"approximate S= {sum}");

    }

}

