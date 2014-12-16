using System;
using NLog;

namespace dbSend.Process
{
    /// <summary>
    ///     Reference: http://trikks.wordpress.com/2012/04/24/creating-a-very-random-password-generator-in-c/
    /// </summary>
    internal class Randomizor
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Random declaration must be done outside the method to actually generate random numbers
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        ///     Generate passwords
        /// </summary>
        /// <param name="passwordLength"></param>
        /// <returns></returns>
        internal static string PasswordGenerator
        {
            get
            {
                var seed = Random.Next(1, int.MaxValue);
                const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";

                var chars = new char[12];
                var rd = new Random(seed);

                for (var i = 0; i < 12; i++)
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }

                return new string(chars);
            }
        }
    }
}