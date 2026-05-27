public static class Hashtable_with_Chaining_Test
{
    private static IEnumerable<Tuple<ulong, int>> CreateStream()
    {
        // Create an empty Entry where you have (x, delta) pairs
        yield return new Tuple<ulong, int>(1, 5);
        yield return new Tuple<ulong, int>(2, 3);
        yield return new Tuple<ulong, int>(1, 4);
        yield return new Tuple<ulong, int>(3, 2);
    }
    public static void TestSquaresum()
    {
        Hashtable_with_Chaining.Init(3, Hashfunctions.MultModPrime);

        IEnumerable<Tuple<ulong, int>> stream = Hashfunctions.CreateStream(100,3);

        ulong result = Hashtable_with_Chaining.squaresum(stream);

        Console.WriteLine($"squaresum should give 94: {result}");
    }

    


}
