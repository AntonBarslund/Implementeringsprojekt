public static class Count_Sketch_Test {

    public static void TestSquaresum()
    {
        int l = 8;
        
        Hashtable_with_Chaining.Init(l, Hashfunctions.MultShift);
        ulong ExactS = Hashtable_with_Chaining.squaresum(Hashfunctions.CreateStream(1000,l));

        Console.WriteLine($"Exact S= {ExactS}");


        // Run this 100 times
        long sum = Count_Sketch.est_square_sum(Hashfunctions.CreateStream(1000,l));
        Console.WriteLine($"approximate S= {sum}");

    }

}

