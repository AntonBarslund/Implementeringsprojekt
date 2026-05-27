public static class Count_Sketch_Test {

    public static void TestSquaresum()
    {
        IEnumerable<Tuple<ulong, int>> stream = Hashfunctions.CreateStream(100,3);

        ulong exactS = Hashtable_with_Chaining.squaresum(stream);

        Console.WriteLine($"True S= {exactS}");

        
    }

}

