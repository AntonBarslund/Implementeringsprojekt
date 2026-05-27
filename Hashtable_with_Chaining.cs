public static class Hashtable_with_Chaining
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
    static Func<ulong, int, ulong> hashFunction = Hashfunctions.MultShift;

    public static void Init(int l, Func<ulong, int, ulong> chosenHashFunction)
    {
        hashBits = l;
        hashFunction = chosenHashFunction;
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
    static int hashBits;

    // Helper function
    public static List<Entry> BucketFor(ulong x)
    {
        ulong h_x = hashFunction(x, hashBits);
        return buckets[(int)h_x];
    }

    public static ulong get(ulong x)
    {
        // Return the value for the key x, or 0 if x is not in the table
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
        // Set the value for the key x to v. If x is not in the table, add it with value v
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
        // Increment the value for the key x by d. If x is not in the table, add it with value d
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

    public static ulong squaresum(List<Entry> stream)
    {
        // Increment the value for each key in the stream
        // by the corresponding delta, and return the sum of squares of all values in the table
        foreach (Entry key in stream)
        {
            increment(key.Key, key.Value);
        }
        // Compute the sum of squares of all values in the table
        ulong sum = 0;
        foreach (List<Entry> bucket in buckets)
        {
            foreach (Entry entry in bucket)
            {
                sum += get(entry.Key) * get(entry.Key); // s(x)^2
            }
        }
        return sum;
    }
}
