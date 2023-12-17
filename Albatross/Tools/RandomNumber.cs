using System;
using System.Security.Cryptography;

namespace Albatross.Tools
{
    public static class RandomNumber
    {
        public static int Next()
        {
            RandomNumberGenerator RNG = RandomNumberGenerator.Create();

            byte[] seedBytes = new byte[4];
            RNG.GetBytes(seedBytes);

            return BitConverter.ToInt32(seedBytes, 0);
        }
    }
}