public static partial class Hashfunctions
{
    // n = number of items in stream
    // l = number of bits to keep from each generated key
    // l determine how many key values (x values) there are so if n = 6 and l = 3 could a stream be
    // (1, 5), (2, 3), (1, 4), (3, 2), (2, 1), (1, 7)
    // Here there is 6 total pairs = n and 3 different keys. for l = 3 there is upto 2^l = 2^3 = 8 different keys
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
