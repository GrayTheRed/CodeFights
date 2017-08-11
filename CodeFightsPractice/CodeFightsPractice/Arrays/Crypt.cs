using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFightsPractice.Arrays
{
    public class Crypt
    {
       
        public Crypt()
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
            //var crypt = new string[] { "AA", "AA", "AA" };
            //var solution = new char[][]
            //{
            //    new char[] {'A', '0'}
            //};

            //Console.WriteLine(IsCrypt(crypt, solution));
            //Console.ReadKey();
        }

        public bool IsCrypt(string[] crypt, char[][] solution)
        {
            var valueList = new List<long>();
            long values = 0;

            foreach (var item in crypt)
            {
                if (!CheckForLeadingZeroes(item, solution))
                {
                    valueList.Add(GetWordValue(item, solution));
                }
                else return false;
            }

            for (int i = 0; i < valueList.Count - 1; i++)
            {
                values += valueList[i];
                
            }

            if (values == valueList[valueList.Count - 1])
            {
                return true;
            }
            else return false;
        }
        
        public long GetWordValue(string word, char[][] solution)
        {
            string wordToNum = String.Empty;
            long returnLong = 0;
            for(int i = 0; i < word.Length; i++)
            {
                for(int j = 0; j < solution.Length; j++)
                {
                    if (word[i] == solution[j][0])
                    {
                        if (word.Length > 1 && i == 0 && solution[j][1] == '0')
                        {
                            return returnLong;
                        }
                        else
                        {
                            wordToNum += solution[j][1];
                            break;
                        }
                    }
                }
            }
            returnLong = Convert.ToInt64(wordToNum);
            return returnLong;
        }

        public bool CheckForLeadingZeroes(string word, char[][] solution)
        {
            bool hasLeadingZero = false;
            if (word.Length > 1)
            {
                for (int j = 0; j < solution.Length; j++)
                {
                    if (word[0] == solution[j][0])
                    {
                        if (solution[j][1] == '0')
                        {
                            hasLeadingZero = true;
                            break;
                        }
                    }
                }
            }
            return hasLeadingZero;
        }
    }
}
