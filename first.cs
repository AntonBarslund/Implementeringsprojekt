
foreach (var item in CreateStream(10, 5))
{
    Console.WriteLine($"{item.Item1}, {item.Item2}");
}

// n = number of items in stream
// 
static IEnumerable<Tuple<ulong, int>> CreateStream(int n, int l)
{
    // We generate a random uint64 number.
    Random rnd = new System.Random();
    ulong a = 0UL;
    Byte[] b = new Byte[8];
    rnd.NextBytes(b);

    for (int i = 0; i < 8; ++i)
    {
        a = (a << 8) + (ulong)b[i] + 1;
    }

    // We demand that our random number has 30 zeros on the
    // least significant bits and then a one.
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


static int mult_shift(int a, int l, int x)
{
    System.Diagnostics.Debug.Assert(l > 0 && l < 64, "l must be between 1 and 64");
    System.Diagnostics.Debug.Assert(l > 0 && l < 64, "l must be between 1 and 64");
    int h = (a*x)>>(64-l);
    return h;
}

Console.WriteLine($"a=1, l=64, x=102 => give a multshift {mult_shift(1,64,102)}");