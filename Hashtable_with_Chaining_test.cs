public static class Hashtable_with_Chaining_Test
{
    public static void TestInit()
    {
        int l = 8;
        IEnumerable<Tuple<ulong, int>> stream = Hashfunctions.CreateStream(1000,l);

        
        Hashtable_with_Chaining.Init(l, Hashfunctions.MultShift);
        ulong ShiftS = Hashtable_with_Chaining.squaresum(stream);

        Hashtable_with_Chaining.Init(l, Hashfunctions.MultModPrime);
        ulong ModS = Hashtable_with_Chaining.squaresum(stream);

        Console.WriteLine($"MultShift S= {ShiftS}, MultModPrime S={ModS}");

        
    }

    public static void TestSquaresum()
    {
        Hashtable_with_Chaining.Init(3, Hashfunctions.MultModPrime);

        IEnumerable<Tuple<ulong, int>> stream = CreateStream();

        ulong result = Hashtable_with_Chaining.squaresum(stream);

        Console.WriteLine($"squaresum should give 94: {result}");
    }

    static ulong[] S =
    {
        1, 332305, 3433212, 32134
    };

    static long[] values =
    {
        2, 3, 4, 5
    };

    private static void InitHashTableWithTestData()
    {
        Hashtable_with_Chaining.Init(3, Hashfunctions.MultShift);

        for (int i = 0; i < S.Length; i++)
        {
            Hashtable_with_Chaining.set(S[i], values[i]);
        }
    }



        private static IEnumerable<Tuple<ulong, int>> CreateStream()
    {
        yield return new Tuple<ulong, int>(1, 5);
        yield return new Tuple<ulong, int>(2, 3);
        yield return new Tuple<ulong, int>(1, 4);
        yield return new Tuple<ulong, int>(3, 2);
    }

    public static void TestGet()
    {
        InitHashTableWithTestData();

        Console.WriteLine($"get(1) should give 2: {Hashtable_with_Chaining.get(1)}");
        Console.WriteLine($"get(332305) should give 3: {Hashtable_with_Chaining.get(332305)}");
        Console.WriteLine($"get(3433212) should give 4: {Hashtable_with_Chaining.get(3433212)}");
        Console.WriteLine($"get(32134) should give 5: {Hashtable_with_Chaining.get(32134)}");
        Console.WriteLine($"get(999) should give 0: {Hashtable_with_Chaining.get(999)}");
    }

    public static void TestSet()
    {
        InitHashTableWithTestData();

        Console.WriteLine($"Before set, get(1) should give 2: {Hashtable_with_Chaining.get(1)}");

        Hashtable_with_Chaining.set(1, 10);

        Console.WriteLine($"After set(1, 10), get(1) should give 10: {Hashtable_with_Chaining.get(1)}");
    }

    public static void TestIncrement()
    {
        InitHashTableWithTestData();

        Console.WriteLine($"Before increment, get(1) should give 2: {Hashtable_with_Chaining.get(1)}");

        Hashtable_with_Chaining.increment(1, 4);

        Console.WriteLine($"After increment(1, 4), get(1) should give 6: {Hashtable_with_Chaining.get(1)}");

        Hashtable_with_Chaining.increment(999, 5);

        Console.WriteLine($"After increment(999, 5), get(999) should give 5: {Hashtable_with_Chaining.get(999)}");
    }


    public static void TestSquaresumRunningTimes()
    {
        // Test of squaresums for given n and l values.
        int n = 10_000_000;
        int[] lValues = { 5, 8, 10, 12, 14, 16, 18, 20, 22 };

        TestSquaresumWithHashFunction("MultModPrime", n, lValues, Hashfunctions.MultModPrime);
        TestSquaresumWithHashFunction("MultShift", n, lValues, Hashfunctions.MultShift);
    }

    private static void TestSquaresumWithHashFunction(
        string hashName,
        int n,
        int[] lValues,
        Func<ulong, int, ulong> hashFunction)
    {
        // Run the sqauresum for the different l values
        foreach (int l in lValues)
        {
            IEnumerable<Tuple<ulong, int>> stream = Hashfunctions.CreateStream(n,l);
            Hashtable_with_Chaining.Init(l, hashFunction);
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            ulong result = Hashtable_with_Chaining.squaresum(stream);
            stopwatch.Stop();
            Console.WriteLine(
                $"{hashName}: n={n}, l={l}, different keys={1 << l}, squaresum={result}, time={stopwatch.Elapsed.TotalMilliseconds:F2} ms"
            );
        }
    }

}
