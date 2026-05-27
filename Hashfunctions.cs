using System.Numerics;
public static partial class Hashfunctions
{
    public static BigInteger Mod(BigInteger x, BigInteger p, int q)
    {
        // y mod p
        // where p = 2^q - 1
        BigInteger y = (x & p) + (x >> q);
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
        BigInteger p = ((BigInteger)1 << q) - 1;
        BigInteger a = BigInteger.Parse("d32f8aecf24447ef", System.Globalization.NumberStyles.HexNumber);
        BigInteger b = BigInteger.Parse("1db6edd77959746f", System.Globalization.NumberStyles.HexNumber);

        // Compute MultModPrime
        BigInteger ax_b = a * (BigInteger)x + b;
        BigInteger result = Mod(ax_b, p, q) % ((BigInteger)1 << l);
        return (ulong) result;
    }

}
