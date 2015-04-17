﻿using System;
using System.Security.Cryptography;

namespace sidekick
{
    /// <summary>
    ///  Code taken from http://scottlilly.com/create-better-random-numbers-in-c/
    /// </summary>
    public static class RandomNumber 
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
 
        public static int GetNumber(int maxValue) {
            return GetNumber(0, maxValue);
        }

        public static int GetNumber(int minValue, int maxValue) {
            byte[] randomNumber = new byte[1];
 
            _generator.GetBytes(randomNumber);
 
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
 
            // We are using Math.Max, and substracting 0.00000000001,
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
 
            // We need to add one to the range, to allow for the rounding done with Math.Floor
            //int range = maximumValue - minimumValue + 1;
            int range = maxValue - minValue;
 
            double randomValueInRange = Math.Floor(multiplier * range);
 
            return (int)(minValue + randomValueInRange);
        }
    }
}
