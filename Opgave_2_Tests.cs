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
        Opgave_2.Init(3);

        for (int i = 0; i < S.Length; i++)
        {
            Opgave_2.set(S[i], values[i]);
        }
    }

    private static List<Opgave_2.Entry> CreateStream()
    {
        return new List<Opgave_2.Entry>
        {
            new Opgave_2.Entry(1, 5),
            new Opgave_2.Entry(2, 3),
            new Opgave_2.Entry(1, 4),
            new Opgave_2.Entry(3, 2)
        };
    }

    public static void TestGet()
    {
        InitHashTableWithTestData();

        Console.WriteLine(Opgave_2.get(1));       // should give 2
        Console.WriteLine(Opgave_2.get(332305));  // should give 3
        Console.WriteLine(Opgave_2.get(3433212)); // should give 4
        Console.WriteLine(Opgave_2.get(32134));   // should give 5
        Console.WriteLine(Opgave_2.get(999));     // should give 0
    }

    public static void TestSet()
    {
        InitHashTableWithTestData();

        Console.WriteLine(Opgave_2.get(1)); // 2

        Opgave_2.set(1, 10);

        Console.WriteLine(Opgave_2.get(1)); // 10
    }

    public static void TestIncrement()
    {
        InitHashTableWithTestData();

        Console.WriteLine(Opgave_2.get(1)); // 2

        Opgave_2.increment(1, 4);

        Console.WriteLine(Opgave_2.get(1)); // 6

        Opgave_2.increment(999, 5);

        Console.WriteLine(Opgave_2.get(999)); // 5
    }

    public static void TestSquaresum()
    {
        Opgave_2.Init(3);

        List<Opgave_2.Entry> stream = CreateStream();

        ulong result = Opgave_2.squaresum(stream);

        Console.WriteLine($"Skal give 94: {result}"); // should give 94
    }
}
