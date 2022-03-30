using System;
using System.Numerics;
/*
 * RSA implementation by C#
 * this program is written by Betül ALBAYRAK
 * all of checks and exceptions are made in the code
 * the rules that I've used are:
 *   1. Choose two prime numbers p and q.
 *   2. Compute n = p*q.
 *   3. Calculate eular = (p-1) * (q-1).
 *   4. Choose an integer e such that 1 < e < eular and gcd(e, eular) = 1; i.e., e and eular are coprime.
 *   5. Calculate d as d ≡ e^−1 (mod eular); here, d is the modular multiplicative inverse of e modulo eular.
 *   6. For encryption, c = m^e mod n, where m = original message.
 *   7. For decryption, m = c^d mod n.
 */
namespace RSA
{
    class Program
    {
        private static bool isPrime(double num)
        {
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private static double gcd(double a, double b)
        {
            double t;
            while (true)
            {
                t = a % b;
                if (t == 0)
                    return b;
                a = b;
                b = t;
            }
            return 0;
        }
        static void Main(string[] args)
        {
            double p, q, e;
            double eular, n, track;
            Console.Write("entering p number from console, then check if it is valid. if it isn't valid enter it agian");
            Console.Write("\nEnter P:");
            p = Convert.ToInt32(Console.ReadLine());
            while (p <= 9 || p > 99 || isPrime(p) != true)
            {
                Console.Write("\nEnter P agian:\nP should be a prime number and has two digits: ");
                p = Convert.ToInt32(Console.ReadLine());
            };

            Console.Write("\nentering q number from console, then check if it is valid. if it isn't valid enter it agian");
            Console.Write("\nEnter Q:");
            q = Convert.ToInt32(Console.ReadLine());
            while (q <= 9 || q > 99 || isPrime(q) != true)
            {
                Console.Write("\nEnter Q agian:\nQ should be a prime number and has two digits: ");
                q = Convert.ToInt32(Console.ReadLine());
            };


            KeyCalculator keyCalculator = new KeyCalculator();

            eular = keyCalculator.EulerFunction(p, q);
            Console.Write("\nthe rule which we used for calculating eular is: (p - 1) * (q - 1)");
            Console.Write("\nthe value for eular is : " + eular);

            n = keyCalculator.PublicKeyN(p, q);
            Console.Write("\nthe rule which we used for calculating n is: p * q");

            Console.Write("\nthe value for n is : " + n);


            //here we checked that:
            // e should be two digits, smaller than eular, 1 < e < eular and gcd(e, eular) = 1; i.e., e and eular are coprime.
            Console.Write("\nEnter e for using it with public key:");
            e = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nfor checking that 1 < e < eular and gcd(e, eular) = 1; i.e., e and eular are coprime.");
            while (e <= 9 || e > 99 || e < eular)
            {
                track = gcd(e, eular);
                if (track == 1)
                    break;
                else {
                    Console.Write("\nEnter e agian: ");
                    e = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.Write("\nthe value for e which we will use is : " + e);

            Console.Write("\nEnter the number which you want to encrypt:");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nthe rule which we used for encryption your number is [c = Math.Pow(m, e) mod n]");

            double c = keyCalculator.Encryption(m, e, n);

            Console.Write("\nyour encrypted number is : " + c);

            Console.Write("\nthe rule which we used for decryption your number is [d = Math.Pow(e, -1) mod eular],and [m = Math.Pow(c, d) mod n]");

            double dec = keyCalculator.Deccryption(c, e, n, eular);

            Console.Write("\nyour deccrypted number is : " + m + "\n\n");
        }
    }
}
