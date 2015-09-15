using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkListProblems
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode resL = new ListNode(0);
            ListNode pL1 = l1;
            ListNode pL2 = l2;
            ListNode result = resL;

            int sum = int.MinValue;
            int preValue = 0;
            while (pL1 != null && pL2 != null)
            {
                sum = pL1.val + pL2.val + preValue;
                preValue = sum / 10;
                sum = sum % 10;

                resL.next = new ListNode(sum);
                pL1 = pL1.next;
                pL2 = pL2.next;
                resL = resL.next;
            }

            while (pL1 != null)
            {
                sum = pL1.val + preValue;
                preValue = sum / 10;
                sum = sum % 10;
                resL.next = new ListNode(sum);
                pL1 = pL1.next;
                resL = resL.next;
            }

            while (pL2 != null)
            {
                sum = pL2.val + preValue;
                preValue = sum / 10;
                sum = sum % 10;
                resL.next = new ListNode(sum);
                pL2 = pL2.next;
                resL = resL.next;
            }

            if (preValue > 0)
            {
                resL.next = new ListNode(preValue);
            }
            return result.next;
        }
    }
}
