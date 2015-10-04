using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversingLinkedListsIteratively
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Node head = null;

            head = AttachNodeToList(head, 0);
            head = AttachNodeToList(head, 1);
            head = AttachNodeToList(head, 2);
            head = AttachNodeToList(head, 3);
            head = AttachNodeToList(head, 4);
            head = AttachNodeToList(head, 5);
            head = AttachNodeToList(head, 6);
            head = AttachNodeToList(head, 7);
            head = AttachNodeToList(head, 8);
            head = AttachNodeToList(head, 9);

            DisplayLinkedList(head);
            head = ReverseLinkedList(head);
            Console.WriteLine();
            DisplayLinkedList(head);
            Console.ReadLine();
        }

        private static Node ReverseLinkedList(Node head)
        {
            Node current = head,
                 previous = null,
                 next;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            head = previous;

            return previous;
        }

        private static Node AttachNodeToList(Node head, int data)
        {
            Node temp = new Node();
            temp.Data = data;
            temp.Next = null;

            if (head == null)
            {
                head = temp;
            }
            else
            {
                Node temp2 = head;
                while (temp2.Next != null)
                {
                    temp2 = temp2.Next;
                }
                temp2.Next = temp;
            }

            return head;
        }

        private static void DisplayLinkedList(Node head)
        {
            while (head != null)
            {
                Console.Write("{0}, ", head.Data);
                head = head.Next;
            }
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }
}
