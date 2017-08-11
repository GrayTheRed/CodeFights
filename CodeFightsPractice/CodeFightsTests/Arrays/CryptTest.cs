using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;


namespace CodeFightsTests.Arrays
{
    using CodeFightsPractice.Arrays;
    [TestClass]
    public class CryptTest
    {
        private readonly Crypt testCrypt = new Crypt();

        [TestMethod]
        public void CryptIsCrypt_ShouldReturnTrue()
        {
            var crypt = new string[] { "SEND", "MORE", "MONEY" };
            var solution = new char[][]
            {
                new char[] {'O', '0' },
                new char[] {'M', '1' },
                new char[] {'Y', '2' },
                new char[] {'E', '5' },
                new char[] {'N', '6' },
                new char[] {'D', '7' },
                new char[] {'R', '8' },
                new char[] {'S', '9' }
            };
            var reply = testCrypt.IsCrypt(crypt, solution);
            Assert.AreEqual(true, reply);
        }

        [TestMethod]
        public void CryptIsCrypt_ShouldReturnFalse()
        {
            var crypt = new string[] { "AA", "AA", "AA" };
            var solution = new char[][]
            {
                new char[] {'A', '0'}
            };
            var reply = testCrypt.IsCrypt(crypt, solution);
            Assert.AreEqual(false, reply);
        }
    }
}
