using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grain_64_Visualize
{
    public class Grain_64
    {
        public byte[] lfsr;
        public byte[] nfsr;
        public byte[] key;
        public Grain_64()
        {
            key = new byte[16];
            lfsr = new byte[8];
            nfsr = new byte[8];
        }

        public int S(byte i)
        {
            int s = (lfsr[7 - (i / 8)]) >> (7 - (i % 8));
            return s;
        }
        public int B(byte i)
        {
            int b = (nfsr[7 - (i / 8)]) >> (7 - (i % 8)); 
            return b;
        }
        public int BuildPolynom(List<object> s,bool func)/*func - S()=false или B()=true*/
        {
            int a=0;
            for (int i = 0; i < s.Count; i++)
            {
                var t = (s[i]).GetType(); 
                if (s[i] is Int32)
                    if (func == false)
                        a ^= S(Convert.ToByte(s[i]));
                    else
                        a ^= B(Convert.ToByte(s[i]));
                if (s[i] is List<object>)
                {
                    int b=0;
                    for (int j = 0; j < ((List<object>)s[i]).Count; j++)
                    {
                        byte x = Convert.ToByte(((List<object>)s[i])[j]);
                        b &= B(x);
                    }
                    a ^= b;
                }
            }
            return a;
        }
        public byte Enc()
        {
            int s64, s0, c1, c2;
            s0 = S(0);
            //s64 = S(62) ^ S(51) ^ S(38) ^ S(23) ^ S(13) ^ s0;
            s64 = BuildPolynom(new List<object> { 62, 51, 38, 23, 13, 0 }, false);
            s64 &= 1;
            c1 = s64;
            for (int i = 0; i < 8; i++)
            {
                c2 = (lfsr[i]) >> 7;
                lfsr[i] = Convert.ToByte((((lfsr[i]) << 1)%256 | c1));
                c1 = c2;
            }
            int b64;
            b64 = BuildPolynom(new List<object> {62,60,52,45,37,33,28,21,14,9,0,new List<object> {63,60},
                new List<object> { 37, 33 },new List<object> {15,9},new List<object> {60,52,45} ,
                new List<object> { 33, 28, 21 }, new List<object> { 63, 45, 28, 9 }, new List<object> {37,33,60,52},
            new List<object> {63,60,21,15},new List<object> {60,52,45,63,37},new List<object> {33,28,21,15,9},
            new List<object> {33,28,21,52,45,37}}, true)^s0;

            c1 = b64 & 1;
            for (int i = 0; i < 8; ++i)
            {
                c2 = (nfsr[i]) >> 7;
                nfsr[i] = Convert.ToByte((((nfsr[i]) << 1)%256 | c1));
                c1 = c2;
            }

            /* h function */
            int x0 = S(3);
            int x1 = S(25);
            int x2 = S(46);
            int x3 = s64;
            int x4 = S(63);
            int h = x1 ^ x4;
            h ^= x0 & x3;
            h ^= x2 & x3;
            h ^= x3 & x4;
            h ^= x0 & x1 & x2;
            h ^= x0 & x2 & x3;
            h ^= x0 & x2 & x4;
            h ^= x1 & x2 & x4;
            h ^= x2 & x3 & x4;

            h ^= B(0) ^ B(1) ^ B(3) ^ B(9) ^ B(30) ^ B(42) ^ B(55);
            return Convert.ToByte(h & 1); 
        }

        static byte reverse_bits(byte a)
        {
            byte[] lut = new byte[16] {0x0, 0x8, 0x4, 0xC,   /* 0000 1000 0100 1100 */
                          0x2, 0xA, 0x6, 0xE,   /* 0010 1010 0110 1110 */
                          0x1, 0x9, 0x5, 0xD,   /* 0001 1001 0101 1101 */
                          0x3, 0xB, 0x7, 0xF }; /* 0011 1011 0111 1111 */
            byte x = Convert.ToByte(((lut[a & 0xf]) << 4) | lut[a >> 4]);
            return x;
        }

        public void Init()
        {
            byte[] k = new byte[8];
            lfsr.CopyTo(k, 0);
            for (int i = 0; i < 8; i++)
            {
                lfsr[7 - i] = reverse_bits(k[i]);
            }
            nfsr.CopyTo(k, 0);
            for (int i = 0; i < 8; i++)
            {              
                nfsr[7 - i] = reverse_bits(k[i]);
            }
        }
    }
}
