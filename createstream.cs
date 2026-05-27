public static partial class Hashfunctions
{
    // n = number of items in stream
    // l = number of bits to keep from each generated key
    public static IEnumerable<Tuple<ulong, int>> CreateStream(int n, int l)
    {
        Random rnd = new System.Random();
        ulong a = 0UL;
        byte[] b = new byte[8];
        rnd.NextBytes(b);

        for (int i = 0; i < 8; ++i)
        {
            a = (a << 8) + (ulong)b[i] + 1;
        }

        a = (a | ((1UL << 31) - 1UL)) ^ ((1UL << 30) - 1UL);
        ulong x = 0UL;

        for (int i = 0; i < n / 3; ++i)
        {
            x = x + a;
            yield return Tuple.Create(x & (((1UL << l) - 1UL) << 30), 1);
        }

        for (int i = 0; i < (n + 1) / 3; ++i)
        {
            x = x + a;
            yield return Tuple.Create(x & (((1UL << l) - 1UL) << 30), -1);
        }

        for (int i = 0; i < (n + 2) / 3; ++i)
        {
            x = x + a;
            yield return Tuple.Create(x & (((1UL << l) - 1UL) << 30), 1);
        }
    }
}
