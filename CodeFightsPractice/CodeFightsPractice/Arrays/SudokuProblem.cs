namespace CodeFightsPractice.Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SudokuProblem
    {
        public int GridLength { get; set; }
        public SudokuProblem()
        {
            char[][] grid = new char[][]
                {
                    new char[] {'.', '.', '.', '1', '4', '.', '.', '2', '.'},
                    new char[] { '.', '.', '6', '.', '.', '.', '.', '.', '.'},
                    new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.'},
                    new char[] { '.', '.', '1', '.', '.', '.', '.', '.', '.'},
                    new char[] { '.', '6', '7', '.', '.', '.', '.', '.', '9'},
                    new char[] { '.', '.', '.', '.', '.', '.', '8', '1', '.'},
                    new char[] { '.', '3', '.', '.', '5', '.', '.', '.', '6'},
                    new char[] { '.', '.', '.', '.', '.', '7', '.', '.', '.'},
                    new char[] { '.', '.', '.', '5', '.', '.', '.', '7', '.'}
                };
            GridLength = grid.GetLength(0);
            var isSudoku = IsSudoku(grid);
            Console.WriteLine(isSudoku);
            Console.ReadKey();
        }
        public bool IsSudoku(char[][] grid)
        {
            if ((!AllColumns(grid)) || (!AllRows(grid)))
            {
                return false;
            }
            else if (!NineByNine(grid))
            {
                return false;
            }
            else return true;
        }

        public bool AllColumns(char[][] grid)
        {
            for (int i = 0; i < GridLength; i++)
            {
                var charList = new List<char>();
                for (int j = 0; j < GridLength; j++)
                {
                    charList.Add(grid[j][i]);
                }
                if (!CheckForDuplicates(charList))
                {
                    return false;
                }
            }
            return true;
        }

        public bool AllRows(char[][] grid)
        {
            for (int i = 0; i < GridLength; i++)
            {
                var charList = new List<char>();
                for (int j = 0; j < GridLength; j++)
                {
                    charList.Add(grid[i][j]);
                }
                if (!CheckForDuplicates(charList))
                {
                    return false;
                }
            }
            return true;
        }
        public bool NineByNine(char[][] grid)
        {
            int stoppingPoint = GridLength - 3;
            for (int i = 0; i <= stoppingPoint; i += 3)
            {
                for (int j = 0; j <= stoppingPoint; j += 3)
                {
                    List<char> charList = new List<char> { grid[i][j], grid[i + 1][j], grid[i + 2][j],
                    grid[i][j+1], grid[i + 1][j+1], grid[i + 2][j+1],
                    grid[i][j+2], grid[i+1][j+2], grid[i+2][j+2] };
                    if (!CheckForDuplicates(charList))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CheckForDuplicates(List<char> charList)
        {
            List<char> numbers = new List<char>();
            foreach(var item in charList)
            {
                switch (item)
                {
                    case '.':
                        break;
                    default:
                        numbers.Add(item);
                        break;
                }
            }

            var distCount = numbers.Distinct();
            if (distCount.Count() != numbers.Count)
            {
                return false;
            }
            else return true;
        }
    }
}
