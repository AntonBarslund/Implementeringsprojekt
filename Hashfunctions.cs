public static partial class Hashfunctions
{
    public static UInt128 Mod(UInt128 x, UInt128 p, int q)
    {
        // y mod p
        // where p = 2^q - 1
        UInt128 y = (x & p) + (x >> q);
        if (y >= p)
        {
            y -= p;
        }

        return y;
    }

    public static ulong MultShift(ulong x, int l = 16)
    {
        // h(x) = \floor{ax mod 2^64 / 2^{64-l}}
        ulong a = 0xebea7d2c9c415295; // The last char is odd so the whole num is odd
        return (a * x) >> (64 - l);
    }

    public static ulong MultModPrime(ulong x, int l = 16)
    {
        int q = 89;
        UInt128 p = (UInt128.One << q) - 1;
        UInt128 a = new UInt128(
           0x0000000001234567UL,
           0x89ABCDEF01234567UL
       );

        UInt128 b = new UInt128(
            0x0000000000ABCDEFUL,
            0x1234567890ABCDEFUL
        );
        // Compute MultModPrime
        UInt128 ax_b = a * (UInt128)x + b;
        UInt128 result = Mod(ax_b, p, q);
        return (ulong)(result % (1UL << l));
    }

}
