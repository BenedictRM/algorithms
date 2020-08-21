// Given a singly linked list L: L0→L1→…→Ln-1→Ln,
// reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…

// You may not modify the values in the list's nodes, only nodes itself may be changed.

// Example 1:
// Given 1->2->3->4, reorder it to 1->4->2->3.

// Example 2:
// Given 1->2->3->4->5, reorder it to 1->5->2->4->3.

namespace algorithms
{
    public class ReorderList
    {
        public static void Solution(ListNode head) {
            if(head == null || head.next == null)
                return;

            ListNode tail = head;
            ListNode runner = head;

            while(tail.next != null) {
                tail = tail.next;
            }

            runner = runner.next;

            head.next = tail;
            tail.next = runner;
            head = runner;

            while(runner.next != tail)
                runner = runner.next;

            runner.next = null;

            Solution(head);
        }
    }
}