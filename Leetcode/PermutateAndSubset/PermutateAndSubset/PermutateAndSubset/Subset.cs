using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateAndSubset
{
    /// <summary>
    /// the difference between subset and permution is:
    /// 1) permuate need index to record the level and end value
    /// 2) permuate need visited array to recode visited value at the same loop
    /// 3) both, need to use index +1, not ++index
    /// </summary>
    public class Subset
    {
        #region Subset with dup
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            if (nums.Length == 0 || nums == null)
            {
                return null;
            }

            List<IList<int>> res = new List<IList<int>>();
            List<int> list = new List<int>();

            DFS(nums, res, list, 0, nums.Length);

            return res;
        }

        public void DFS(int[] nums, List<IList<int>> res, List<int> list, int start, int end)
        {
            res.Add(new List<int>(list));

            for (int i = start; i < end; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }
                list.Add(nums[i]);
                DFS(nums, res, list, i + 1, end);
                list.Remove(nums[i]);
            }
        }
        #endregion

        #region Subset
        public IList<IList<int>> Subsets(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> result = new List<IList<int>>();

            if (nums.Length == 0 || nums == null)
            {
                return result;
            }

            List<int> list = new List<int>();

            SubsetDFS(nums, 0, nums.Length - 1, result, list);

            return result;
        }

        private void SubsetDFS(int[] nums, int start, int end, List<IList<int>> result, List<int> temp)
        {
            result.Add(new List<int>(temp));

            for (int i = start; i <= end; i++)
            {
                temp.Add(nums[i]);
                SubsetDFS(nums, i + 1, end, result, temp);
                temp.Remove(nums[i]);
            }
        }
        #endregion

        #region Permutation
        public List<List<int>> Permute(int[] nums)
        {
            //Array.Sort(nums);
            List<List<int>> result = new List<List<int>>();
            if (nums.Length == 0 || nums == null)
            {
                return result;
            }

            List<int> list = new List<int>();
            bool[] visited = new bool[nums.Length];
            PermutateDFS(nums, result, list, visited, nums.Length, 0);

            return result;
        }

        private void PermutateDFS(int[] nums, List<List<int>> result, List<int> list, bool[] visited, int end, int index)
        {
            if (index == end)
            {
                result.Add(new List<int>(list));
                return;
            }

            for (int i = 0; i < end; i++)
            {
                if (visited[i])
                {
                    continue;
                }
                list.Add(nums[i]);
                visited[i] = true;

                //index +1 just run one time each time, ++ will run all the times
                PermutateDFS(nums, result, list, visited, end, index + 1);
                visited[i] = false;
                list.RemoveAt(index);
            }
        }


        #endregion

        #region Permutation duplicated
        public List<List<int>> PermuteWithDup(int[] nums)
        {
            Array.Sort(nums);
            List<List<int>> result = new List<List<int>>();
            if (nums.Length == 0 || nums == null)
            {
                return result;
            }

            List<int> list = new List<int>();
            bool[] visited = new bool[nums.Length];
            PermutateWidhDupDFS(nums, result, list, visited, nums.Length, 0);

            return result;
        }

        private void PermutateWidhDupDFS(int[] nums, List<List<int>> result, List<int> list, bool[] visited, int end, int index)
        {
            if (index == end)
            {
                result.Add(new List<int>(list));
                return;
            }

            for (int i = 0; i < end; i++)
            {
                if (visited[i] || (i != 0 && nums[i] == nums[i - 1] && !visited[i - 1]))
                {
                    continue;
                }
                list.Add(nums[i]);
                visited[i] = true;
                //index +1 just run one time each time, ++ will run all the times
                PermutateWidhDupDFS(nums, result, list, visited, end, index + 1);
                visited[i] = false;
                list.RemoveAt(index);
            }
        }


        #endregion
    }
}
