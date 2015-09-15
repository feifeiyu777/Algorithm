using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkListProblems llist = new LinkListProblems();

            ListNode l1 = new ListNode(1);
            //l1.next = new ListNode(4);
            //l1.next.next = new ListNode(3);

            ListNode l2 = new ListNode(9);
            l2.next = new ListNode(9);
            //l2.next.next = new ListNode(4);

            llist.AddTwoNumbers(l1,l2);
        }
    }
}
