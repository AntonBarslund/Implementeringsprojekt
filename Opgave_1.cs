public static class Opgave_1 {
    // n = number of items in stream
    public static IEnumerable<Tuple<ulong, int>> CreateStream(int n, int l) {
        // We generate a random uint64 number.
        Random rnd = new System.Random();
        ulong a = 0UL;
        byte[] b = new byte[8];
        rnd.NextBytes(b);

        for (int i = 0; i < 8; ++i) {
            a = (a << 8) + (ulong)b[i] + 1;
        }

        // Demand that the random number has 30 zeros on the least significant bits and then a one.
        a = (a | ((1UL << 31) - 1UL)) ^ ((1UL << 30) - 1UL);
        ulong x = 0UL;

        for (int i = 0; i < n / 3; ++i) {
            x = x + a;
            yield return Tuple.Create(x & (((1UL << l) - 1UL) << 30), 1);
        }

        for (int i = 0; i < (n + 1) / 3; ++i) {
            x = x + a;
            yield return Tuple.Create(x & (((1UL << l) - 1UL) << 30), -1);
        }

        for (int i = 0; i < (n + 2) / 3; ++i) {
            x = x + a;
            yield return Tuple.Create(x & (((1UL << l) - 1UL) << 30), 1);
        }
    }

    public static ulong Mod(ulong x, ulong p, int q) {
        ulong y = (x & p) + (x >> q);
        if (y >= p) {
            y -= p;
        }

        return y;
    }

    public static ulong MultShift(ulong x) {
        ulong a = 102682031;
        int l = 3;
        return (a * x) >> (64 - l);
    }

    public static ulong MultModPrime(ulong x) {
        int q = 89;
        ulong p = (1UL << q) - 1UL;
        ulong a = 102682031;
        ulong b = 11111111UL;
        int l = 3;
        return Mod((a * x + b), p, q) % (1UL << l);
    }
}
