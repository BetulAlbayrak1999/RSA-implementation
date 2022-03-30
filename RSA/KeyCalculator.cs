using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class KeyCalculator
    {
        public double EulerFunction(double p, double q)          //euler function: f(n) = (p-1)(q-1)
        {
            return  (p - 1) * (q - 1);
        }
        public double PublicKeyN(double p, double q)        // public key n
        {
            return p * q;
        }
        public double Encryption(double m, double e, double n) //encryption
        {
            double c;
            c = Math.Pow(m, e);
            c = c % n;
            return c;
        }
        public double Deccryption(double c, double e, double n, double eular) //decryption
        {
            double m, d, d1;
            d1 = 1/e;
            d = d1 % eular;
            Console.Write("\nyour private key is : " + d);
            m = Math.Pow(c, d);
            m = m % n;
            return m;
        }

    }
}
