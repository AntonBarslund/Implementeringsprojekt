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

    private static void InitWithTestData()
    {
        Opgave_2.Init(3);

        for (int i = 0; i < S.Length; i++)
        {
            Opgave_2.set(S[i], values[i]);
        }
    }

    public static void TestGet()
    {
        InitWithTestData();

        Console.WriteLine(Opgave_2.get(1));       // should give 2
        Console.WriteLine(Opgave_2.get(332305));  // should give 3
        Console.WriteLine(Opgave_2.get(3433212)); // should give 4
        Console.WriteLine(Opgave_2.get(32134));   // should give 5
        Console.WriteLine(Opgave_2.get(999));     // should give 0
    }

    public static void TestSet()
    {
        InitWithTestData();

        Console.WriteLine(Opgave_2.get(1)); // 2

        Opgave_2.set(1, 10);

        Console.WriteLine(Opgave_2.get(1)); // 10
    }

    public static void TestIncrement()
    {
        InitWithTestData();

        Console.WriteLine(Opgave_2.get(1)); // 2

        Opgave_2.increment(1, 4);

        Console.WriteLine(Opgave_2.get(1)); // 6

        Opgave_2.increment(999, 5);

        Console.WriteLine(Opgave_2.get(999)); // 5
    }
}
