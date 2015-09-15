using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutateAndSubset
{
    class Program
    {
        static void Main(string[] args)
        {
            Subset sSet = new Subset();
            //sSet.SubsetsWithDup(new int[]{1,1});

            sSet.PermuteWithDup(new int[] { 1, 1, 2 });
            Console.ReadLine();
        }
    }
}
