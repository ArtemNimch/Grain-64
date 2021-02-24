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
            int b = (nfsr[7 - (i / 8)]) >> (7 - (i % 8)); ;
            return b;
        }
        public byte Enc()
        {
            int s64, s0, c1, c2;
            s0 = S(0);
            s64 = S(62) ^ S(51) ^ S(38) ^ S(23) ^ S(13) ^ s0;
            s64 &= 1;
            c1 = s64;
            for (int i = 0; i < 8; i++)
            {
                c2 = (lfsr[i]) >> 7;
                lfsr[i] = Convert.ToByte( (((lfsr[i]) << 1) | c1)%256);
                c1 = c2;
            }
            int b80, a,b,d,e;
            b80 = B(62) ^ B(60) ^ B(52) ^ B(45) ^
                B(37) ^ B(33) ^ B(28) ^ B(21) ^
                B(14) ^ B(9) ^ B(0) ^ s0;
            b80 ^= (a = B(63) & B(60));
            b80 ^= (b = B(37) & B(33));
            b80 ^= B(15) & B(9);
            b80 ^= (d = B(60) & B(52) & B(45));
            b80 ^= (e = B(33) & B(28) & B(21));
            b80 ^= B(63) & B(45) & B(28) & B(9);
                                                 
            b80 ^= b & B(60) & B(52);
            b80 ^= a & B(21) & B(15);
            b80 ^= d & B(63) & B(37); 
            b80 ^= e & B(15) & B(9); 
            b80 ^= e & B(52) & B(45) & B(37);

            c1 = b80 & 1;
            for (int i = 0; i < 8; ++i)
            {
                c2 = (nfsr[i]) >> 7;
                nfsr[i] = Convert.ToByte((((nfsr[i]) << 1) | c1) % 256);
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
