using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseWords("the sky is blue");
        }

        #region Reverse string
        public static string ReverseWords(string s)
        {
            if (s == null || s.Length == 0) { return s; }
            int n = s.Length;            
            char[] chars = new char[n]; 
            int i = n - 1;
            int index = 0;

            for (int k = 0; k <= n - 1; k++)
            {
                chars[k] = '\0'; 
            }
            while (i >= 0)
            {
                while (i >= 0 && s[i] == ' ') {
                    i--; 
                }
                if (i >= 0)
                {
                    if (index != 0) 
                    {
                        chars[index++] = ' '; 
                    }
                    int j = i;
                    while (j >= 0 && s[j] != ' ') {
                        j--; 
                    }
                    for (int k = j + 1; k <= i; k++)
                    { 
                        chars[index++] = s[k];
                    }
                    i = j;
                }
            }

            string r = new String(chars, 0, index);
            return r;
        }
        #endregion
        private static void TestCases()
        {
            //QuickSort(new int[] { 2, 5, 1, 6, 7, 4 });
            //SummaryRanges(new int[] { 0, 1, 2, 4, 5, 7, 8 });
            //ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });

            //LargestNumber(new int[] { 3, 30, 34, 5, 9 });
            //int ele = FindKthLargest(new int[] { 2, 5, 1, 6, 7, 4 }, 3);

            ListNode head = new ListNode(1);
            ListNode p = head;
            p.next = new ListNode(2);
            for (int i = 2; i <= 3; i++)
            {
                p.next = new ListNode(i);
                p = p.next;
            }

            p.next = new ListNode(2);
            p = p.next;
            p.next = new ListNode(1);
            IsPalindrome(head);
            ListNode q = head;

            q = q.next;
            double x = Math.Pow(3, 2);
        }


        #region Palindrome link list
        static ListNode tempHead;
        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }
            tempHead = head;
            return IsPalin(head);
        }

        private static bool IsPalin(ListNode head)
        {
            //current node is the last one
            if (head.next == null)
            {
                return head.val == tempHead.val;
            }

            //when return true, head is the last second one
            bool res = IsPalin(head.next);
            tempHead = tempHead.next;
            return res && head.val == tempHead.val;
        }
        #endregion

        #region sort linked list
        public static ListNode sortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            // step 1. cut the list to two halves
            ListNode prev = null, slow = head, fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null;

            // step 2. sort each half
            ListNode l1 = sortList(head);
            ListNode l2 = sortList(slow);

            // step 3. merge l1 and l2
            return merge(l1, l2);
        }

        public static ListNode merge(ListNode l1, ListNode l2)
        {
            ListNode l = new ListNode(0), p = l;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    p.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    p.next = l2;
                    l2 = l2.next;
                }
                p = p.next;
            }

            if (l1 != null)
                p.next = l1;

            if (l2 != null)
                p.next = l2;

            return l.next;
        }

        #endregion

        #region rotated array
        public static void RotatedArray(int[] nums, int k)
        {
            if (nums.Length == 0 || nums == null) return;

            if (nums.Length == 1)
                return;
            k = k % nums.Length;
            int len = nums.Length - 1;
            for (int i = 0; i < k; i++)
            {
                int temp = nums[len];
                for (int j = nums.Length - 1; j > i; j--)
                {
                    nums[j] = nums[j - 1];
                }
                nums[i] = temp;
            }
        }
        #endregion

        #region generate matrix
        public static int[,] generateMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            if (n < 1)
                return matrix;

            int[,] directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            int i = 0, j = -1, num = 1;

            for (int count = 0; n > 0; count++)
            {
                if ((count & 1) == 1) n--;

                for (int k = 0; k < n; k++)
                {
                    i += directions[count % 4, 0];
                    j += directions[count % 4, 1];
                    matrix[i, j] = num++;
                }
            }

            return matrix;
        }
        #endregion

        #region reorder linkedlist

        public static void ReorderList(ListNode head)
        {
            ListNode lN = head;
            ListNode fast = head;
            ListNode slow = head;
            ListNode pre = null;

            while (fast != null && fast.next != null)
            {
                pre = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            //reverse from slow to fast
            ListNode dummy = null;
            ListNode cur = slow;
            while (cur != null)
            {
                ListNode next = cur.next;
                cur.next = dummy;
                dummy = cur;
                cur = next;
            }

            //merge two part of link list
            ListNode rN = dummy;
            ListNode newHead = lN;
            while (lN != null)
            {
                ListNode lnNext = lN.next;
                ListNode rnNext = rN.next;

                lN.next = rN;
                //left part to the end, then right part just leave it as it
                if (lnNext == null)
                {
                    break;
                }

                rN.next = lnNext;

                lN = lnNext;
                rN = rnNext;
            }
        }
        #endregion
        public static string LargestNumber(int[] nums)
        {
            Array.Sort(nums, (a, b) => (b + "" + a).CompareTo(a + "" + b));

            return nums[0] == 0 ? "0" : string.Join("", nums);

        }

        public static int comparor(object a, object b)
        {
            return (b + "" + a).CompareTo(a + "" + b);
        }

        #region Three Sum equal to zero
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (nums.Length == 0 || nums == null)
            {
                return res;
            }

            Array.Sort(nums);//nlogn
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                int j = i + 1;
                int k = nums.Length - 1;
                int twosum;
                while (j < k)
                {
                    twosum = nums[i] + nums[j];
                    if (twosum + nums[k] > 0) //two bigger, k need to pointer to smaller element
                    {
                        k--;
                    }
                    else if (twosum + nums[k] < 0)
                    {
                        j++;
                    }
                    else
                    {
                        List<int> list = new List<int>();
                        list.Add(nums[i]);
                        list.Add(nums[j]);
                        list.Add(nums[k]);
                        res.Add(list);

                        while (++j < nums.Length && nums[j] == nums[j - 1]) ;
                        while (--k > i && nums[k] == nums[k + 1]) ;
                    }
                }
            }

            return res;
        }
        #endregion

        public static int[] SingleNumber(int[] nums)
        {
            int[] res = new int[2];
            if (nums.Length == 0 || nums == null)
            {
                return res;
            }

            HashSet<int> hasSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!hasSet.Add(nums[i]))
                {
                    hasSet.Remove(nums[i]);
                }
            }

            int c = 0;
            foreach (int i in hasSet)
            {
                res[c] = i;
                c++;
            }

            return res;
        }
        public static bool IsPalindrome(int x)
        {
            int y = x;
            int parNum = 0;
            while (y >= 1)
            {
                //get the last digital of x
                parNum = parNum * 10 + y % 10;
                y = y / 10;
            }

            return x < 0 ? false : parNum == x;
        }
        public static IList<string> SummaryRanges(int[] nums)
        {
            IList<string> res = new List<string>();
            if (nums.Length == 0 || nums == null)
            {
                return res;
            }

            int start = nums[0];
            int end = start;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] + 1 == nums[i])
                {
                    end = nums[i];
                }
                else
                {//consider same value
                    if (start == end)
                    {
                        res.Add(start.ToString());
                    }
                    else
                    {
                        res.Add(start.ToString() + "->" + end.ToString());
                    }
                    start = nums[i];
                    end = nums[i];
                }
            }
            if (start == end)
            {
                res.Add(start.ToString());
            }
            else
            {
                res.Add(start.ToString() + "->" + end.ToString());
            }
            return res;
        }
        #region Quick sort
        public static void QuickSort(int[] array)
        {
            if (array.Length == 0 || array == null)
            {
                return;
            }

            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int low, int hi)
        {
            if (low < hi)
            {
                int p = Partition(array, low, hi);
                QuickSort(array, low, p - 1);
                QuickSort(array, p + 1, hi);
            }
        }

        private static int Partition(int[] array, int low, int hi)
        {
            int pivot = array[hi];
            int i = low;
            //j = low, partition second part
            for (int j = low; j < hi - 1; j++)
            {
                if (array[j] <= pivot)
                {
                    Swap(array, i, j);
                    i++;
                }
            }

            Swap(array, i, hi);
            return i;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        #endregion

        #region Find Kth largest element
        public static int FindKthLargest(int[] nums, int k)
        {
            if (nums.Length == 0 || nums == null)
            {
                return 0;
            }

            return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
        }

        private static int QuickSelect(int[] nums, int left, int right, int k)
        {
            //Only one element

            int pivot = PartitionSelect(nums, left, right);

            if (k == pivot)
            {
                return nums[pivot];
            }
            else if (k < pivot)
            {
                return QuickSelect(nums, left, pivot - 1, k);
            }
            else
            {
                return QuickSelect(nums, pivot + 1, right, k);
            }
        }

        private static int PartitionSelect(int[] nums, int start, int end)
        {
            if (end == start)
                return end;
            int maxid = start;
            int pivot = nums[end];
            for (int i = start; i < end; ++i)
            {
                // compare to the pivot value and make sure we won't swap the same index
                if (nums[i] < pivot)
                {
                    // swap the value to the left
                    Swap(nums, maxid, i);
                    maxid++;
                }
            }

            //swap the pivot value
            Swap(nums, maxid, end);

            return maxid;
        }

        #endregion
    }
}
