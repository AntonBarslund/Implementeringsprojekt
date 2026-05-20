

ulong sum1 = 0;
var sw1 = System.Diagnostics.Stopwatch.StartNew();
long iter1 = 0;
int cpIndex1 = 0;
long[] checkpoints = new long[] { 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000 };

foreach (var item in CreateStream(1000000000, 5))
{
    iter1++;
    sum1 += mult_shift(item.Item1);

    if (cpIndex1 < checkpoints.Length && iter1 == checkpoints[cpIndex1])
    {
        // cumulative time at this checkpoint
        Console.WriteLine($"mult_shift: iterations={iter1}, elapsed={sw1.Elapsed.TotalMilliseconds:F3} ms");
        System.IO.File.AppendAllText("mult_shift_times.csv", $"{iter1},{sw1.Elapsed.TotalMilliseconds:F3}\n");
        cpIndex1++;
    }
}
sw1.Stop();
Console.WriteLine($"Mult_shift sum: {sum1}  Total time: {sw1.Elapsed.TotalMilliseconds:F3} ms");

// Test of mutiply mod prime
ulong sum2 = 0;
var sw2 = System.Diagnostics.Stopwatch.StartNew();
long iter2 = 0;
int cpIndex2 = 0;

foreach (var item in CreateStream(1000000000, 5))
{
    iter2++;
    sum2 += mult_mod_prime(item.Item1);

    if (cpIndex2 < checkpoints.Length && iter2 == checkpoints[cpIndex2])
    {
        Console.WriteLine($"mult_mod_prime: iterations={iter2}, elapsed={sw2.Elapsed.TotalMilliseconds:F3} ms");
        System.IO.File.AppendAllText("mult_mod_prime_times.csv", $"{iter2},{sw2.Elapsed.TotalMilliseconds:F3}\n");
        cpIndex2++;
    }
}
sw2.Stop();
Console.WriteLine($"mult_mod_prime sum: {sum2}  Total time: {sw2.Elapsed.TotalMilliseconds:F3} ms");




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

static ulong mod(ulong x, ulong p, int q)
{
    ulong y = (x&p)+(x>>q);
    if (y>=p) y-=p;
    return y;
}

static ulong mult_shift(ulong x)
{
    ulong a = 102682031;
    int l = 34;
    return (a*x)>>(64-l);
}

static ulong mult_mod_prime(ulong x)
{
    int q = 89;
    ulong p = (1UL << q) - 1UL;
    ulong a = 6435631;
    ulong b = 11111111UL;
    int l = 36;
    return  mod((a*x+b) , p, q) % (1UL << l);
}




//Console.WriteLine($"a=1,  l=61, x=102 => give a multshift {mult_shift(102)}");
//Console.WriteLine($"a=1, b=2, l=61, x=102 => give a multshift {mult_mod_prime(102)}");