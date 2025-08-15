using System;

class Program
{
    static void Main()
    {
        const int MAXN = 1_000_000;

        // Criba de Eratóstenes
        var isPrime = new bool[MAXN + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;

        for (int p = 2; p * p <= MAXN; p++)
        {
            if (isPrime[p])
            {
                for (int m = p * p; m <= MAXN; m += p)
                    isPrime[m] = false;
            }
        }

        // Prefijos: pref[i] = #primos en [0..i]
        var pref = new int[MAXN + 1];
        for (int i = 1; i <= MAXN; i++)
            pref[i] = pref[i - 1] + (isPrime[i] ? 1 : 0);

        // Lectura de casos hasta "0 0"
        string? line;
        while ((line = Console.ReadLine()) != null)
        {
            line = line.Trim();
            if (line.Length == 0) continue;

            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;

            int L = int.Parse(parts[0]);
            int R = int.Parse(parts[1]);

            if (L == 0 && R == 0) break;

            if (L < 1) L = 1;
            if (R > MAXN) R = MAXN;

            if (L > R)
            {
                Console.WriteLine(0);
                continue;
            }

            int ans = pref[R] - pref[L - 1];
            Console.WriteLine(ans);
        }
    }
}
