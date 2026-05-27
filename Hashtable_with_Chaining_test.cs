public static class Opgave2_Tests
{
    static ulong[] S =
    {
        1, 332305, 3433212, 32134
    };

    static ulong[] values =
    {
        2, 3, 4, 5
    };

    private static void InitHashTableWithTestData()
    {
        Hashtable_with_Chaining.Init(3);

        for (int i = 0; i < S.Length; i++)
        {
            Hashtable_with_Chaining.set(S[i], values[i]);
        }
    }

    private static List<Hashtable_with_Chaining.Entry> CreateStream()
    {
        return new List<Hashtable_with_Chaining.Entry>
        {
            new Hashtable_with_Chaining.Entry(1, 5),
            new Hashtable_with_Chaining.Entry(2, 3),
            new Hashtable_with_Chaining.Entry(1, 4),
            new Hashtable_with_Chaining.Entry(3, 2)
        };
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

    public static void TestSquaresum()
    {
        Hashtable_with_Chaining.Init(3);

        List<Hashtable_with_Chaining.Entry> stream = CreateStream();

        ulong result = Hashtable_with_Chaining.squaresum(stream);

        Console.WriteLine($"squaresum should give 94: {result}");
    }
}
