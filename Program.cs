using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringHash("cx"));
            Console.ReadKey();
        }
        public static int StringHash(String inputs)
        {
            inputs.Replace('/', '\\');
            inputs = inputs.ToUpperInvariant();
            byte[] s_ = Encoding.UTF8.GetBytes(inputs);
            int n = 0;
            int len = s_.Length;
            int sizt_t = len;
            int A = -1640531527;
            int B = -1640531527;
            int C = 0;
            while (len >= 12)
            {
                A += Intercepting(ref s_, n);
                B += Intercepting(ref s_, n + 4);
                C += Intercepting(ref s_, n + 8);
                T1(ref A, ref B, ref C);
                n += 12;
                len -= 12;
            }
            C += sizt_t;
            if (len == 11) { C += s_[n + 10] * 0x1000000; len -= 1; }
            if (len == 10) { C += s_[n + 9] * 0x10000; len -= 1; }
            if (len == 9) { C += s_[n + 8] * 0x100; len -= 1; }
            if (len == 8) { B += s_[n + 7] * 0x1000000; len -= 1; }
            if (len == 7) { B += s_[n + 6] * 0x10000; len -= 1; }
            if (len == 6) { B += s_[n + 5] * 0x100; len -= 1; }
            if (len == 5) { B += s_[n + 4]; len -= 1; }
            if (len == 4) { A += s_[n + 3] * 0x1000000; len -= 1; }
            if (len == 3) { A += s_[n + 2] * 0x10000; len -= 1; }
            if (len == 2) { A += s_[n + 1] * 0x100; len -= 1; }
            if (len == 1) { A += s_[n]; len -= 1; }
            T1(ref A, ref B, ref C);
            return C;
        }
        private static void T1(ref int A, ref int B, ref int C)
        {
            A = (C >> 13) & 0x7FFFF ^ (A - B - C);
            B = (A << 8) ^ (B - C - A);
            C = (B >> 13) & 0x7FFFF ^ (C - A - B);
            A = (C >> 12) & 0xFFFFF ^ (A - B - C);
            B = (A << 16) ^ (B - C - A);
            C = (B >> 5) & 0x7FFFFFF ^ (C - A - B);
            A = (C >> 3) & 0x1FFFFFFF ^ (A - B - C);
            B = (A << 10) ^ (B - C - A);
            C = (B >> 15) & 0x1FFFF ^ (C - A - B);
        }
        private static int Intercepting(ref byte[] byteArray, int location)
        {
            return (byteArray[location + 3] << 24) | (byteArray[location + 2] << 16) | (byteArray[location + 1] << 8) | byteArray[location];
        }
    }
}
