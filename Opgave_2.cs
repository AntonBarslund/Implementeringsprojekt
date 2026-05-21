public static class Opgave_2
{
    // Entry stores a key-value pair (x_i, delta_i)
    public class Entry
    {
        public ulong Key;
        public ulong Value;

        public Entry(ulong key, ulong value)
        {
            Key = key;
            Value = value;
        }
    }

    public static void Init(int l)
    {
        int m = 1 << l; // Number of buckets: m = 2^l

        // Create the bucket array
        buckets = new List<Entry>[m];

        // Create one chain/list for each bucket
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new List<Entry>();
        }
    }

    // Static field storing the array of buckets
    static List<Entry>[] buckets = null!;

    // Helper function
    public static List<Entry> BucketFor(ulong x)
    {
        ulong h_x = Opgave_1.MultModPrime(x);
        return buckets[(int)h_x];
    }

    public static ulong get(ulong x)
    {
        List<Entry> bucket = BucketFor(x);
        foreach (Entry entry in bucket)
        {
            if (entry.Key == x)
            {
                return entry.Value;
            }
        }
        return 0;
    }

    public static void set(ulong x, ulong v)
    {
        List<Entry> bucket = BucketFor(x);
        foreach (Entry entry in bucket)
        {
            if (entry.Key == x)
            {
                entry.Value = v;
                return;
            }
        }
        bucket.Add(new Entry(x, v));
    }

    public static void increment(ulong x, ulong d)
    {
        List<Entry> bucket = BucketFor(x);
        foreach (Entry entry in bucket)
        {
            if (entry.Key == x)
            {
                entry.Value += d;
                return;
            }
        }
        bucket.Add(new Entry(x, d));
    }
}



