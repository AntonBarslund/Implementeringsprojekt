public static class Opgave_4
{

    static long[] C = null!;
    static int k;

    public static ulong com_g_x(ulong x)
    {
        // Compute g(x) = a_0 + a_1x + a_2x^2 + a_3x^3 mod p

        var a_i = new List<ulong> { 0x3467c1c009414b89, 0x5c81bff301f58b22, 0x7cfa97b8ff79f984, 0x4e44586dc28a8b31 };
        int k = a_i.Count; // k = 4
        int q = 89;
        ulong p = (1UL << 89) - 1UL; // p = 2^q - 1 = 2^89 - 1
        ulong y = a_i[k - 1]; // a_i[3]


        for (int i = k - 2; k >= 0; k--)
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
    public static (ulong h_x, long s_x) init_values(ulong g_x)
    {
        // Lad t <= 64 , da er m = 2^t <= 2^64
        // g: U -> [p]
        int q = 89;
        int t = 10;
        ulong m = (1UL << t);   // 2^t <= 2^64
        ulong h_x = g_x & (m - 1UL); // h(x) = g(x) mod m
        ulong q_x = g_x >> (q - 1);
        ulong s_x = 1L - 2 * q_x;
        return (h_x, (long)s_x);
    }

    // Count sketch
    public static void bsc_init(double eps)
    {
        k = (int)Math.Ceiling(4 / Math.Pow(eps, 2)); // k <- celling(4/eps^2)
        C = new long[k]; // C[0,...,k-1] <- 0
    }

    public static void bsc_process(ulong x, long delta)
    {
        ulong g_x = com_g_x(x);
        var (h_x, s_x) = init_values(g_x);
        C[(int)h_x] = C[h_x] + s_x * delta;
    }

    // public static ulong bsc_query(ulong x) {
    //ulong g_x = com_g_x(x);
    //var (h_x, s_x) = init_values(g_x);
    //  return s_x * C[h_x];
    // }

}


