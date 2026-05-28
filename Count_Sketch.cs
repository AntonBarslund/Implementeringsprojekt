using System.Numerics;
public static class Count_Sketch
{
    public class Entry
    {
        public ulong Key;
        public long Value;

        public Entry(ulong key, long value)
        {
            Key = key;
            Value = value;
        }
    }

    static long[] C = null!;
    static int k;
    static int t;
    static int q = 89;
    static BigInteger p = ((BigInteger)1 << 89) - 1;
    static List<ulong> a_i = null!;

    public static BigInteger com_g_x(ulong x)
    {
        // Compute g(x) = a_0 + a_1x + a_2x^2 + a_3x^3 mod p

        int n = a_i.Count; // n = 4
        BigInteger y = a_i[n - 1]; // a_i[3]


        for (int i = n - 2; i >= 0; i--)
        {
            y = y * x + a_i[i];
            y = (y & p) + (y >> q);
        }

        if (y >= p)
        {
            y -= p;
        }

        return y;
    }


    // Opgave 5
    public static (ulong h_x, long s_x) init_values(BigInteger g_x)
    {
        // g: U -> [p]
        ulong h_x = (ulong)(g_x & (k - 1)); // h(x) = g(x) mod k
        long q_x = (long)(g_x >> (q - 1)); // 0 or 1
        long s_x = 1L - 2L * q_x;    // +1 or -1
        return (h_x, s_x);
    }

    // Count sketch
    public static void bsc_init(double eps, ulong rand)
    {
        a_i = new List<ulong> { 0x3467c1c009414b89 + rand, 0x5c81bff301f58b22 + rand, 0x7cfa97b8ff79f984 + rand, 0x4e44586dc28a8b31 + rand };
        k = (int)Math.Ceiling(8 / Math.Pow(eps, 2)); // k <- celling(8/eps^2)
        t = (int)Math.Ceiling(Math.Log2(k));
        C = new long[k]; // C[0,...,k-1] <- 0
    }

    public static void bsc_process(ulong x, long delta)
    {
        BigInteger g_x = com_g_x(x);
        var (h_x, s_x) = init_values(g_x);
        C[(int)h_x] = C[h_x] + s_x * delta;
    }

    public static long bsc_query(ulong x)
    {
        BigInteger g_x = com_g_x(x);
        var (h_x, s_x) = init_values(g_x);
        return s_x * C[h_x];
    }

    public static long est_square_sum(IEnumerable<Tuple<ulong, int>> stream, ulong rand)
    {
        double eps = 0.3536;
        Count_Sketch.bsc_init(eps, rand);
        foreach (Tuple<ulong, int> item in stream)
        {
            Count_Sketch.bsc_process(item.Item1, item.Item2);
        }

        // Compute the sum of squares of all values in the table
        long sum = 0;
        foreach (long entry in C)
        {
            sum += entry * entry;
        }
        return sum;
    }

}


