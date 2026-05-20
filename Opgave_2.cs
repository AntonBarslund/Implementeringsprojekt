public static class Opgave_2
{
    public static void Run()
    {
        int l = 3;
        int m = 1 << l;
        List<ulong>[] buckets = new List<ulong>[m];

        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new List<ulong>();
        }
        ulong[] S =
        {
            1, 332305, 3433212, 32134
        };

        for (int i = 0; i < S.Length; i++)
        {
            ulong x = S[i];
            ulong h_x = Opgave_1.MultModPrime(S[i]);
            buckets[(int)h_x].Add(x);
            Console.WriteLine($"x = {x}, h(x) = {h_x}");
        }
    }
}
