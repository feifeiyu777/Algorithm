using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTracking
{
    public class NPProblems
    {
        public void SolveSudoku(int[,] board)
        {

        }


        #region N Queen wayI
        public List<string[]> SolveNQueens(int n)
        {
            List<string[]> res = new List<string[]>();
            helper(n, 0, new int[n], res);
            return res;
        }
        private void helper(int n, int row, int[] columnForRow, List<string[]> res)
        {
            if (row == n)
            {
                string[] item = new string[n];
                for (int i = 0; i < n; i++)
                {
                    StringBuilder strRow = new StringBuilder();
                    for (int j = 0; j < n; j++)
                    {
                        if (columnForRow[i] == j)
                            strRow.Append('Q');
                        else
                            strRow.Append('.');
                    }
                    item[i] = strRow.ToString();
                }
                res.Add(item);
                return;
            }
            for (int i = 0; i < n; i++)
            {
                columnForRow[row] = i;
                if (check(row, columnForRow))
                {
                    helper(n, row + 1, columnForRow, res);
                }
            }
        }
        private bool check(int row, int[] columnForRow)
        {
            for (int i = 0; i < row; i++)
            {
                if (columnForRow[row] == columnForRow[i])
                    return false;

                if (Math.Abs(columnForRow[row] - columnForRow[i]) == Math.Abs(row - i))
                    return false;
            }
            return true;
        }
        #endregion

        #region N Queen Way II
        public IList<IList<string>> SolveNQueensII(int n)
        {
            IList<IList<string>> res = new List<IList<string>>();

            if (n <= 0)
            {
                return res;
            }

            char[,] board = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = '.';
                }
            }
            NQueenHelper(n, board, 0, res);

            return res;
        }

        private void NQueenHelper(int n, char[,] board, int row, IList<IList<string>> res)
        {
            //scean the etnire board
            if (row == n)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        sb.Append(board[i, j].ToString());
                    }
                }

                List<string> list = new List<string>();
                list.Add(sb.ToString());
                res.Add(list);

                return;
            }

            for (int col = 0; col < n; col++)
            {
                //IsValid used to check if current row,col is available to put a Q
                if (board[row, col] == '.' && IsValid(n, row, col, board))
                {
                    board[row, col] = 'Q';
                    NQueenHelper(n, board, row + 1, res);
                    //once current way is added into res, then remove it and start try next possible ways
                    board[row, col] = '.';
                }
            }
        }

        private bool IsValid(int n, int row, int col, char[,] board)
        {
            //check if col in each row has a Q
            for (int i = 0; i < n; i++)
            {
                if (board[i, col] == 'Q')
                {
                    return false;
                }
            }

            //check if row in each col has a Q
            for (int j = 0; j < n; j++)
            {
                if (board[row, j] == 'Q')
                {
                    return false;
                }
            }

            int rowPosi = row;
            int colPosi = col;
            //check 4 directions diagnoal
            while (rowPosi >= 0 && colPosi >= 0)
            {
                if (board[rowPosi--, colPosi--] == 'Q')
                {
                    return false;
                }
            }

            rowPosi = row;
            colPosi = col;
            while (rowPosi < n && colPosi < n)
            {
                if (board[rowPosi++, colPosi++] == 'Q')
                {
                    return false;
                }
            }

            rowPosi = row;
            colPosi = col;
            while (rowPosi >= n && colPosi < n)
            {
                if (board[rowPosi--, colPosi++] == 'Q')
                {
                    return false;
                }
            }

            rowPosi = row;
            colPosi = col;
            while (rowPosi < n && colPosi >= 0)
            {
                if (board[rowPosi++, colPosi--] == 'Q')
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region N Queen way III
        private String[] drawChessboard(List<int> cols)
        {
            String[] chessboard = new String[cols.Count];
            for (int i = 0; i < cols.Count; i++)
            {
                chessboard[i] = "";
                for (int j = 0; j < cols.Count; j++)
                {
                    if (j == cols[i])
                    {
                        chessboard[i] += "Q";
                    }
                    else
                    {
                        chessboard[i] += ".";
                    }
                }
            }

            return chessboard;
        }

        private bool isValid(List<int> cols, int col)
        {
            int row = cols.Count;
            for (int i = 0; i < row; i++)
            {
                // same column
                if (cols[i] == col)
                {
                    return false;
                }
                // left-top to right-bottom
                if (i - cols[i] == row - col)
                {
                    return false;
                }
                // right-top to left-bottom
                if (i + cols[i] == row + col)
                {
                    return false;
                }
            }
            return true;
        }

        private void search(int n, List<int> cols, List<String[]> result)
        {
            if (cols.Count == n)
            {
                result.Add(drawChessboard(cols));
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (!isValid(cols, col))
                {
                    continue;
                }
                cols.Add(col);
                search(n, cols, result);
                cols.RemoveAt(cols.Count - 1);
            }
        }

        public List<String[]> SolveNQueensIII(int n)
        {
            List<String[]> result = new List<String[]>();
            if (n <= 0)
            {
                return result;
            }
            search(n, new List<int>(), result);
            return result;
        }

        #endregion

        #region N Queen way IIII
        public List<string[]> SolveNQueueIIII(int n)
        {
            List<string[]> res = new List<string[]>();
            if (n <= 0)
            {
                return res;
            }

            string[] rows = new string[n];

            NQueenDFS(n, 0, res, rows);

            return res;
        }

        private void NQueenDFS(int n, int staRow, List<string[]> res, string[] rows)
        {
            if (staRow >= n)
            {
                res.Add((string[])rows.Clone());
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (!IsValidIIII(staRow, col, rows))
                {
                    continue;
                }

                char[] chars = new char[n];
                for (int i = 0; i < n; i++)
                {
                    chars[i] = '.';
                }
                chars[col] = 'Q';

                rows[staRow] = new string(chars);
                NQueenDFS(n, staRow + 1, res, rows);
            }
        }

        private bool IsValidIIII(int staRow, int col, string[] rows)
        {
            for (int i = 0; i < staRow; i++)
            {
                int qCol = rows[i].IndexOf('Q');

                //current col has a Q
                if (qCol == col)
                {
                    return false;
                }

                int rowDistance = Math.Abs(staRow - i);
                int colDistance = Math.Abs(col - qCol);

                //check diagonal, only if |x-xi|==|y-yi| 
                if (rowDistance == colDistance)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region N Queen II way I
        public int TotalNQueens(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            int[] res = new int[1];
            int staRow = 0;
            string[] rows = new string[n];

            NQueenIIDFS(n, staRow, res, rows);
            return res[0];
        }

        private void NQueenIIDFS(int n, int staRow, int[] res, string[] rows)
        {
            if (staRow >= n)
            {
                //once screan the entire board, put the queen on corret position
                int temp = 1;
                res[0] += temp;
                return;
            }

            for (int col = 0; col < n; col++)
            {
                if (!IsValidQueenIIDFS(staRow, col, rows))
                {
                    continue;
                }

                char[] chars = new char[n];
                for (int i = 0; i < n; i++)
                {
                    chars[i] = '.';
                }

                chars[col] = 'Q';
                rows[staRow] = new string(chars);
                NQueenIIDFS(n, staRow + 1, res, rows);
            }
        }

        private bool IsValidQueenIIDFS(int staRow, int col, string[] rows)
        {
            for (int i = 0; i < staRow; i++)
            {
                int qCol = rows[i].IndexOf('Q');

                //check current col and Q in all prevoius row's col
                if (col == qCol)
                {
                    return false;
                }

                int rowDist = Math.Abs(staRow - i);
                int colDist = Math.Abs(col - qCol);

                //row distanct equal col distanct on both direction diagonal
                if (rowDist == colDist)
                {
                    return false;
                }
            }

            return true;
        }


        #endregion

        #region Solve Sudoku
        public void SolveSudoku(char[,] board)
        {
            if (board == null || board.GetLength(0) != 9 || board.GetLength(1) != 9)
            {
                return;
            }

            SolveSudokuDFS(board, 0, 0);
        }

        private bool SolveSudokuDFS(char[,] board, int row, int col)
        {
            if (col >= 9)
            {
                return SolveSudokuDFS(board, row + 1, 0);
            }

            if (row == 9)
            {
                return true;
            }

            if (board[row, col] == '.')
            {
                for (int k = 1; k <= 9; k++)
                {
                    board[row, col] = (char)(k + '0');
                    if (IsValid(board, row, col))
                    {
                        if (SolveSudokuDFS(board, row, col + 1))
                        {
                            return true;
                        }
                    }
                    board[row, col] = '.';
                }
            }
            else
            {
                return SolveSudokuDFS(board, row, col + 1);
            }
            return false;
        }

        //Check if row, col and each 3X3 matrix no repeated values
        private bool IsValid(char[,] board, int i, int j)
        {
            for (int k = 0; k < 9; k++)
            {
                if (k != i && board[k, j] == board[i, j])
                    return false;
            }
            for (int k = 0; k < 9; k++)
            {
                if (k != j && board[i, k] == board[i, j])
                    return false;
            }
            for (int row = i / 3 * 3; row < i / 3 * 3 + 3; row++)
            {
                for (int col = j / 3 * 3; col < j / 3 * 3 + 3; col++)
                {
                    if (row != i && col != j && board[i, j] == board[row, col])
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region Combination Sum
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> res = new List<IList<int>>();

            if (candidates.Length == 0 || candidates == null || target <= 0)
            {
                return res;
            }

            Array.Sort(candidates);

            List<int> list = new List<int>();

            CombinationSumIDFS(candidates, target, list, res, 0);

            return res;
        }

        private void CombinationSumIDFS(int[] candidates, int target, List<int> list, List<IList<int>> res, int index)
        {
            if (target == 0)
            {
                res.Add(new List<int>(list));
                return;
            }

            if (target < 0)
            {
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                //optimize code
                if (target < candidates[i])
                {
                    break;
                }
                list.Add(candidates[i]);

                //index =i, if items can be reused, e.g. 2,2...
                CombinationSumIDFS(candidates, target - candidates[i], list, res, i);
                list.RemoveAt(list.Count - 1);
            }
        }
        #endregion

        #region Combinations Sum II
        public IList<IList<int>> CombinationSumII(int[] candidates, int target)
        {
            List<IList<int>> res = new List<IList<int>>();

            if (candidates.Length == 0 || candidates == null || target <= 0)
            {
                return res;
            }

            Array.Sort(candidates);

            List<int> list = new List<int>();

            CombinationSumIIDFS(candidates, target, list, res, 0);

            return res;
        }

        //remove the dup
        private void CombinationSumIIDFS(int[] candidates, int target, List<int> list, List<IList<int>> res, int index)
        {
            if (target == 0)
            {
                res.Add(new List<int>(list));
                return;
            }

            if (target < 0)
            {
                return;
            }

            int pre = -1;
            for (int i = index; i < candidates.Length; i++)
            {
                //optimize code
                if (target < candidates[i])
                {
                    break;
                }

                //remove dup
                if (pre != -1 && pre == candidates[i])
                {
                    continue;
                }

                list.Add(candidates[i]);

                //index =i, next round from next value
                CombinationSumIIDFS(candidates, target - candidates[i], list, res, i + 1);
                list.RemoveAt(list.Count - 1);
                pre = candidates[i];
            }
        }
        #endregion

        #region Combination Sum III
        public IList<IList<int>> CombinationSumIII(int k, int target)
        {
            List<IList<int>> res = new List<IList<int>>();

            if (k <= 0 || target <= 0)
            {
                return res;
            }


            List<int> list = new List<int>();

            CombinationSumIIIDFS(k, target, list, res, 1);

            return res;
        }

        private void CombinationSumIIIDFS(int k, int target, List<int> list, List<IList<int>> res, int index)
        {
            if (k == 0 && target == 0)
            {
                res.Add(new List<int>(list));
                return;
            }

            if (k == 0 || target < 0)
            {
                return;
            }

            for (int i = index; i <= 9; i++)
            {
                list.Add(i);
                CombinationSumIIIDFS(k - 1, target - i, list, res, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
        #endregion
    }
}
